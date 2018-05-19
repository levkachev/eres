using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;

namespace TrainMovement.Interpolation.Rusi4
{
    /// <inheritdoc cref="BaseModeControl" />
    /// <summary>
    /// Режим ведения "Ход 1" для ЭПС 81/740.1 (Русич)
    /// </summary>
    public class Pull1 : BasePull, IPull
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <exception cref="!:ArgumentNullException">value is <see langword="null" /></exception>
        private Pull1(Mass characteristics) => ForceAndCurrent = ElectricTractionCharacteristicsRepository.GetVfiRusi4Pull1(characteristics);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public static Pull1 GetInstance(Mass characteristics) => GetInstance<Pull1>(characteristics);
    }
}
