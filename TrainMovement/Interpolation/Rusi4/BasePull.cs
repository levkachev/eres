using System;
using ORM.Trains.Entities;
using TrainMovement.ModeControl;
using TrainMovement.Train;

namespace TrainMovement.Interpolation.Rusi4
{
    /// <inheritdoc cref="BaseModeControl" />
    /// <summary>
    /// Базовый класс, описывающий режим "Тяга".
    /// </summary>
    public abstract class BasePull : BaseModeControl, IPull
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        public override Double GetForce(Double velocity, BaseTrain train) =>
            train.TimeInModeControl < train.Machine.AssemblyPullTime
                ? 0.0
                : GetForceAndCurrent(velocity, train.Mass).Force;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public override IModeControl High(Mass characteristics) => this;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public override IModeControl Low(Mass characteristics) => GetInstance<Inert>(characteristics);
    }
}