using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;

namespace TrainMovement.Interpolation
{/// <summary>
 /// Pull2
 /// </summary>
    internal class Pull2Rusi4 : BaseModeRusi4<Pull2Rusi4>
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Pull2Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Pull2(mass);
        }

        public override IModeControl Low(MassMass mass)
        {
            return InertRusi4.GetInstance(mass);
        }

        public static Pull2Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Pull2Rusi4>(mass);
        }
    }
}
