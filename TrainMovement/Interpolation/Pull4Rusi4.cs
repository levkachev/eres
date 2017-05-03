using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Pull4
    /// </summary>
    internal class Pull4Rusi4 : BaseModeRusi4
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Pull4Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Pull4(mass);
        }
    }
}

