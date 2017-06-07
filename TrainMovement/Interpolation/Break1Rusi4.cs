using System;
using System.Linq;
using ORM.Helpers;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;
using TrainMovement.Train;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break1
    /// </summary>
    public class Break1Rusi4 : BaseModeRusi4<Break1Rusi4>, IRecuperationBreak
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        private Break1Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break1(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl Low(MassMass mass)
        {
            return Break2Rusi4.GetInstance(mass);
        }

        /// <summary>
        /// Переход в режим торможения со средним замедлением
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl High(MassMass mass)
        {
            return BreakAverageRusi4.GetInstance();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Break1Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Break1Rusi4>(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return $"Break1";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override Double GetCurrent(Double velocity, BaseTrain train)
        {
            return GetForceAndCurrent(velocity, train.Mass).Item2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override Double GetForce(Double velocity, BaseTrain train)
        {
            return GetForceAndCurrent(velocity, train.Mass).Item1;
        }

        private Tuple<Double, Double> GetForceAndCurrent(Double velocity, Double mass)
        {
            try
            {
                var vfi1 = vfi.Last(v => v.Key <= velocity);
                var vfi2 = vfi.First(v => v.Key >= velocity);

                var v1 = vfi1.Key;
                var v2 = vfi2.Key;

                var f1 = GetForce(vfi1);
                var f2 = GetForce(vfi2);

                var c1 = GetCurrent(vfi1);
                var c2 = GetCurrent(vfi2);

                var k1 = 0.0;
                var k2 = 0.0;


                //только при скорости 0 MathHelper.IsEqual(vfi1.Key, vfi2.Key)!!! если будет выше 85 - УПАДЕМ!!!

                if (!MathHelper.IsEqual(vfi1.Key, vfi2.Key))
                {
                    k1 = GetK(v1, v2, f1, f2);

                    k2 = GetK(v1, v2, c1, c2);

                }

                var force = k1 * velocity + GetB(v1, k1, f1);
                var current = k2 * velocity + GetB(v1, k2, c1);

                if (current < 0)
                    force = -force;
                return new Tuple<Double, Double>(force, current);
            }
            catch
            {
                throw new ArgumentOutOfRangeException(nameof(velocity));
            }
        }

        /// <summary>
        /// Коэффициент К прямой
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        private static Double GetK(Double x1, Double x2, Double y1, Double y2)
        {
            return (y1 - y2) / (x1 - x2);
        }

        /// <summary>
        /// Коэффициент В прямой
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="k"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        private static Double GetB(Double x1, Double k, Double y1)
        {
            return y1 - k * x1;
        }
    }
}
