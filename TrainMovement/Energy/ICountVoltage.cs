using System;
using System.Collections.Generic;

namespace TrainMovement.Energy
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICountVoltage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="piketage"></param>
        /// <returns></returns>
        Double GetVoltage(Double current, Double piketage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="piketage"></param>
        /// <returns></returns>
        IEnumerable<Double> GetVoltages(Double piketage);
    }
}