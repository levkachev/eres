using System;
using ORM.Trains.Entities;
using TrainMovement.Train;

namespace TrainMovement.Interpolation.Rusi4
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    public class BreakAverage: BaseBreak
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public override Double GetEfficiency(Double velocity) => 0;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        public override Double GetForce(Double velocity, BaseTrain train) => 0;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        public override Double GetCurrent(Double velocity, BaseTrain train) => 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public static BreakAverage GetInstance(Mass characteristics) => GetInstance<BreakAverage>(characteristics);
    }
}