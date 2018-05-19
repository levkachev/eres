using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;

namespace TrainMovement.Interpolation.Rusi4
{
    /// <inheritdoc cref="BaseModeControl" />
    /// <summary>
    /// Режим ведения "Ход 2" для ЭПС 81/740.1 (Русич)
    /// </summary>
    public class Pull2 : BasePull, IPull
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <exception cref="!:ArgumentNullException">value is <see langword="null" /></exception>
        private Pull2(Mass mass) => ForceAndCurrent = ElectricTractionCharacteristicsRepository.GetVfiRusi4Pull2(mass);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public static Pull2 GetInstance(Mass characteristics) => GetInstance<Pull2>(characteristics);

    }
}
