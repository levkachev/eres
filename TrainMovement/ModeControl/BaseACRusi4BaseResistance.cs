using System;
using TrainMovement.Train;
using TrainMovement.Stages;

namespace TrainMovement.ModeControl
{
    /// <summary>
    /// Расчет силы основого оспротивления для Русича
    /// </summary>
    public abstract class BaseACRusi4BaseResistance
    {
        /// <summary>
        /// Сила основного сопротивления
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        public Double GetBaseResistance(BaseTrain train)
        {
            const Double coefficient1 = 1.1;
            const Double coefficient2 = 0.01;
            const Double coefficient3 = 0.001;

            var coefficientOpenStage = train.CurrentStage.GetCoefficientOpenStage(train.Space);

            var trainWeightFactor = train.UnladenWeight / (train.UnladenWeight + train.Mass);

            return coefficient1 * trainWeightFactor
                + coefficient2 * train.Velocity 
                + coefficient3 * trainWeightFactor * train.Velocity * train.Velocity * coefficientOpenStage;
        }
    }
}
