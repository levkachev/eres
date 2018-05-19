using System;
using TrainMovement.Train;

namespace TrainMovement.ModeControl
{
    /// <summary>
    /// Интерфейс для определения дополнительного сопротивления
    /// </summary>
    public interface IResistance
    {
        /// <summary>
        /// Расчёт дополнительного сопотивления
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        Double GetAdditionalResistance(BaseTrain train);
    }
}