using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Pull4
    /// </summary>
    internal class Pull4Rusi4 : BaseModeRusi4<Pull4Rusi4>
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Pull4Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Pull4(mass);
        }

        public override IModeControl Low(MassMass mass)
        {
            return InertRusi4.GetInstance(mass);
        }

        public static Pull4Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Pull4Rusi4>(mass);
        }
    }
}

