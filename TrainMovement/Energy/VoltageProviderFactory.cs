using System;

namespace TrainMovement.Energy
{
    /// <summary>
    /// 
    /// </summary>
    public class VoltageProviderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly EventBroker broker;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="broker"></param>
        public VoltageProviderFactory(EventBroker broker)
        {
            this.broker = broker;
        }

        /// <summary>
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">value is <see langword="null" /></exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        public BaseVoltageProvider GetVoltageProvider(String filename = null, String separator = "; ")
        {
            if (filename == null)
                return new ConstantVoltageProvider(broker, 825);
            return new FileVoltageProvider(broker, filename, separator);
        }
    }
}