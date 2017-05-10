using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break2
    /// </summary>
    internal class Break2Rusi4 : BaseModeRusi4<Break2Rusi4>
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Break2Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break2(mass);
        }

        public override IModeControl Low(MassMass mass)
        {
            return GetInstance<Break3Rusi4>(mass);
        }

        public static Break2Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Break2Rusi4>(mass);
        }
    }
}

