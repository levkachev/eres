using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break1
    /// </summary>
    internal class Break1Rusi4 : BaseModeRusi4<Break1Rusi4>
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Break1Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break1(mass);
        }

        public override IModeControl Low(MassMass mass)
        {
            return Break2Rusi4.GetInstance(mass);
        }

        public static Break1Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Break1Rusi4>(mass);
        }
    }
}
