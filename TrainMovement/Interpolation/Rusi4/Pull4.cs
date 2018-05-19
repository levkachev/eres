using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;

namespace TrainMovement.Interpolation.Rusi4
{
    /// <inheritdoc cref="BaseModeControl" />
    /// <summary>
    /// Режим ведения "Ход 4" для ЭПС 81/740.1 (Русич)
    /// </summary>
    public class Pull4 : BasePull, IPull
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <exception cref="!:ArgumentNullException">value is <see langword="null" /></exception>
        private Pull4(Mass mass) => ForceAndCurrent = ElectricTractionCharacteristicsRepository.GetVfiRusi4Pull4(mass);
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Pull4 GetInstance(Mass mass) => GetInstance<Pull4>(mass);
    }
}

