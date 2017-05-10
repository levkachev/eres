using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break3
    /// </summary>
    internal class Break3Rusi4 : BaseModeRusi4<Break3Rusi4>
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Break3Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break3(mass);
        }

        public static Break3Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Break3Rusi4>(mass);
        }

        public override IModeControl Low(MassMass mass)
        {
            return this;
        }
    }
}
