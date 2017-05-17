using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break2
    /// </summary>
    public class Break2Rusi4 : BaseModeRusi4<Break2Rusi4>, IBreak
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        private Break2Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break2(mass);
        }

        public override IModeControl Low(MassMass mass)
        {
            return BaseModeRusi4<Break3Rusi4>.GetInstance<Break3Rusi4>(mass);
        }

        public static Break2Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Break2Rusi4>(mass);
        }
        public override IModeControl High(MassMass mass)
        {
           return BaseModeRusi4<InertRusi4>.GetInstance<InertRusi4>(mass);
        }
    }
}

