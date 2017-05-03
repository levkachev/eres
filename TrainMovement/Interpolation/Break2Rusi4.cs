using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break2
    /// </summary>
    internal class Break2Rusi4 : BaseModeRusi4
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Break2Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break2(mass);
        }
    }
}

