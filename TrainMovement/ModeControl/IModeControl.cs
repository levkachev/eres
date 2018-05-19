using System;
using ORM.Trains.Entities;
using TrainMovement.Train;

namespace TrainMovement.ModeControl
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModeControl
    {
        /// <summary>
        /// Получение силы
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        Double GetForce(Double velocity, BaseTrain train);

        /// <summary>
        /// Получение тока
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        Double GetCurrent(Double velocity, BaseTrain train);

        /// <summary>
        /// Получение К.П.Д.
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        Double GetEfficiency(Double velocity);
        
        /// <summary>
        /// Расчёт основного сопротивления
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        Double GetBaseResistance(BaseTrain train);

        /// <summary>
        /// Понижение режима ведения
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        IModeControl Low(Mass characteristics);

        /// <summary>
        /// Повышение режима ведения
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        IModeControl High(Mass characteristics);
    }
}