using System;
using TrainMovement.Train;

namespace TrainMovement.ModeControl
{
    /// <summary>
    /// Интерфейс для определения основного и дополнительного сопротивления
    /// </summary>
    public interface IResistance
    {
        /// <summary>
        /// Расчет основного сопротивления
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        Double GetBaseResistance(BaseTrain train);

        /// <summary>
        /// Расчет дополнительного сопотивления
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        Double GetAdditionalResistance(BaseTrain train);
    }
}