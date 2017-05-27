using System;
using TrainMovement.Train;

namespace TrainMovement.Energy
{
    /// <summary>
    /// 
    /// </summary>
    public class SimpleVoltage : ICountVoltage
    {
        /// <summary>
        /// 
        /// </summary>
        private const Double maxVoltage = 950;

        /// <summary>
        /// 
        /// </summary>
        private EventBroker broker;

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
                if (value < 0 || value > maxVoltage)
                    throw new ArgumentOutOfRangeException(nameof(value));
                voltage = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="piketage"></param>
        /// <returns></returns>
        public Double GetVoltage(Double current, Double piketage)
        {
            return Voltage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voltage"></param>
        /// <param name="broker"></param>
        public SimpleVoltage(Double voltage, EventBroker broker)
        {
            Voltage = voltage;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Listen()
        {
            broker.Subscribe(new EventHandler(OnTrainChangingSpace));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTrainChangingSpace(Object sender, EventArgs e)
        {
            var train = sender as BaseTrain;
            if (train == null )
                return;
            train.Voltage = GetVoltage(train.SpacePiketage, train.Current);
        }
    }
}
