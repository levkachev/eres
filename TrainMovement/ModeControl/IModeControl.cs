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
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        Double GetForce(Double velocity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        Double GetCurrent(Double velocity);

        /// <summary>
        /// Расчет основного сопротивления
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        Double GetBaseResistance(BaseTrain train);

        /// <summary>
        /// Понижение режимы ведения
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        IModeControl Low(MassMass mass);


        /// <summary>
        /// Понижение режимы ведения
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        IModeControl High(MassMass mass);
    }
}