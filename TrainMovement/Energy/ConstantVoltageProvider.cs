using System;
using System.Collections.Generic;

namespace TrainMovement.Energy
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstantVoltageProvider : BaseVoltageProvider
    {
        /// <summary>
        /// 
        /// </summary>
        private const Double MaxVoltage = 950;

        /// <summary>
        /// 
        /// </summary>
        private Double voltage;

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double Voltage
        {
            get { return voltage; }
            set
            {
                if (value < 0 || value > MaxVoltage)
                    throw new ArgumentOutOfRangeException(nameof(value));
                voltage = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="broker"></param>
        /// <param name="voltage"></param>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        public ConstantVoltageProvider(EventBroker broker, Double voltage)
        {
            Broker = broker;
            Voltage = voltage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="piketage"></param>
        /// <returns></returns>
        public override Double GetVoltage(Double current, Double piketage)
        {
            return Voltage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="piketage"></param>
        /// <returns></returns>
        public override IEnumerable<Double> GetVoltages(Double piketage)
        {
            return new[] { Voltage };
        }
    }
}
