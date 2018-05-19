using System;
using ORM.Trains.Entities;
using TrainMovement.ModeControl;
using TrainMovement.Train;

namespace TrainMovement.Interpolation.Rusi4
{
    /// <inheritdoc cref="BaseModeControl" />
    /// <summary>
    /// </summary>
    public class Inert : BaseModeControl, IInert
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        public override Double GetCurrent(Double velocity, BaseTrain train) => 0;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public override IModeControl Low(Mass characteristics) => BreakAverage.GetInstance(characteristics);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"/>
        public override IModeControl High(Mass characteristics) => throw new NotImplementedException();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Inert GetInstance(Mass mass) => GetInstance<Inert>(mass);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private Inert(Mass mass)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        public override Double GetForce(Double velocity, BaseTrain train) => 0;
    }
}