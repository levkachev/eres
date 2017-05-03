using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break1
    /// </summary>
    internal class Break1Rusi4 : BaseModeRusi4
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Break1Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break1(mass);
        }
    }
}
