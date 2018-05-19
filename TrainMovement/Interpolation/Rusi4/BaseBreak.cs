using System;
using System.Linq;
using ORM.OldHelpers;
using ORM.Trains.Entities;
using TrainMovement.ModeControl;
using TrainMovement.Train;

namespace TrainMovement.Interpolation.Rusi4
{
    public class BaseBreak : BaseModeControl, IBreak
    {
        public override Double GetForce(Double velocity, BaseTrain train) =>
                train.TimeInModeControl < train.Machine.AssemblyBreakTime
                    ? 0.0
                    : GetForceAndCurrent(velocity, train.Mass).Force;

        /// <summary>
        /// Переход в режим торможения со средним замедлением
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public override IModeControl Low(Mass characteristics) =>
        GetInstance<BreakAverage>(characteristics);

        public override IModeControl High(Mass characteristics) =>
            GetInstance<Inert>(characteristics);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="mass"></param>
        /// <returns></returns>
        protected override (Double Force, Double Current) GetForceAndCurrent(Double velocity, Double mass)
        {
            try
            {
                var vfi1 = Characteristics.Last(v => v.Key <= velocity);
                var vfi2 = Characteristics.First(v => v.Key >= velocity);

                var v1 = vfi1.Key;
                var v2 = vfi2.Key;

                var f1 = GetForce(vfi1);
                var f2 = GetForce(vfi2);

                var c1 = GetCurrent(vfi1);
                var c2 = GetCurrent(vfi2);

                var k1 = 0.0;
                var k2 = 0.0;

                //WARNING только при скорости 0 MathHelper.IsEqual(vfi1.Key, vfi2.Key)!!! если будет выше 85 - УПАДЕМ!!!
                if (!vfi1.Key.IsEqual(vfi2.Key))
                {
                    k1 = MathHelper.GetK(v1, v2, f1, f2);
                    k2 = MathHelper.GetK(v1, v2, c1, c2);
                }

                var force = k1 * velocity + MathHelper.GetB(v1, k1, f1);
                var current = k2 * velocity + MathHelper.GetB(v1, k2, c1);

                if (current < 0)
                    force = -force;

                return (force, current);
            }
            catch
            {
                throw new ArgumentOutOfRangeException(nameof(velocity));
            }
        }

    }
}
