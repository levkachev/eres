using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break3
    /// </summary>
    public class Break3Rusi4 : BaseModeRusi4<Break3Rusi4>, IBreak
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        private Break3Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break3(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Break3Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Break3Rusi4>(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl Low(MassMass mass)
        {
            return this;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl High(MassMass mass)
        {
            return BaseModeRusi4<InertRusi4>.GetInstance<InertRusi4>(mass);
        }
    }
}
