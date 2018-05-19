using System;
using System.Linq;
using ORM.OldHelpers;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;
using TrainMovement.Train;

namespace TrainMovement.Interpolation.Rusi4
{
    /// <inheritdoc cref="BaseModeControl" />
    /// <summary>
    /// Режим ведения "Тормоз 1" для ЭПС 81/740.1 (Русич)
    /// </summary>
    public class Break1 : BaseBreak
    {
        /// <inheritdoc />
        ///  <summary>
        ///  </summary>
        ///  <exception cref="T:System.ArgumentNullException">value is <see langword="null" /></exception>
        private Break1(Mass characteristics) => ForceAndCurrent = ElectricTractionCharacteristicsRepository.GetVfiRusi4Break1(characteristics);
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public static Break1 GetInstance(Mass characteristics) => GetInstance<Break1>(characteristics);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        public override Double GetCurrent(Double velocity, BaseTrain train) => GetForceAndCurrent(velocity, train.Mass).Current;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        public override Double GetForce(Double velocity, BaseTrain train) => GetForceAndCurrent(velocity, train.Mass).Force;

       
    }
}
