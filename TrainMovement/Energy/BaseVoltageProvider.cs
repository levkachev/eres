using System;
using System.Collections.Generic;
using TrainMovement.Train;

namespace TrainMovement.Energy
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseVoltageProvider : ICountVoltage
    {
        /// <summary>
        /// 
        /// </summary>
        private EventBroker broker;

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        public EventBroker Broker
        {
            get { return broker; }
            protected set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                broker = value;
                Listen();
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        public void Listen()
        {
            Broker.Subscribe(new EventHandler(OnTrainChangingSpace));
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        protected void OnTrainChangingSpace(Object sender, EventArgs e)
        {
            var train = sender as BaseTrain;
            if (train == null)
                return;
            train.Voltage = GetVoltage(train.Current, train.SpacePiketage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="piketage"></param>
        /// <returns></returns>
        public abstract Double GetVoltage(Double current, Double piketage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="piketage"></param>
        /// <returns></returns>
        public abstract IEnumerable<Double> GetVoltages(Double piketage);
    }
}