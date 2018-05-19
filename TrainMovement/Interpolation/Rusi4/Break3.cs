using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;

namespace TrainMovement.Interpolation.Rusi4
{
    /// <inheritdoc cref="BaseModeControl" />
    /// <summary>
    /// Режим ведения "Тормоз 3" для ЭПС 81/740.1 (Русич)
    /// </summary>
    public class Break3 : BaseBreak
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">value is <see langword="null" /></exception>
        private Break3(Mass characteristics) => ForceAndCurrent = ElectricTractionCharacteristicsRepository.GetVfiRusi4Break3(characteristics);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public static Break3 GetInstance(Mass characteristics) => GetInstance<Break3>(characteristics);
    }
}
