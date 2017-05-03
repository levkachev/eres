using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Pull3
    /// </summary>
    internal class Pull3Rusi4 : BaseModeRusi4
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Pull3Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Pull3(mass);
        }
    }
}
