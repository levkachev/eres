using System;

namespace TrainMovement.Energy
{
    public interface ICountVoltage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="piketage"></param>
        /// <returns></returns>
        Double GetVoltage(Double current, Double piketage);
    }
}