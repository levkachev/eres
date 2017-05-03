using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;

namespace TrainMovement.Interpolation
{/// <summary>
 /// Pull2
 /// </summary>
    internal class Pull2Rusi4 : BaseModeRusi4
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Pull2Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Pull2(mass);
        }
    }
}
