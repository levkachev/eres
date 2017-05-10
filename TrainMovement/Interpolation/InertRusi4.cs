using System;
using ORM.Trains.Entities;
using TrainMovement.ModeControl;

namespace TrainMovement.Interpolation
{
    /// <summary>
    /// 
    /// </summary>
    internal class InertRusi4 : BaseModeRusi4<InertRusi4>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public override Double GetCurrent(Double velocity)
        {
            return 0;
        }

        public override IModeControl Low(MassMass mass)
        {
            return Break1Rusi4.GetInstance(mass);
        }

        public static InertRusi4 GetInstance(MassMass mass)
        {
            return GetInstance<InertRusi4>(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public override Double GetForce(Double velocity)
        {
            return 0;
        }
    }
}