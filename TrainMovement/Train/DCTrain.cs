using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Machine;

namespace TrainMovement.Train
{
    /// <summary>
    /// 
    /// </summary>
    public class DCTrain : BaseTrain
    {
        /// <summary>
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="commonProperties"></param>
        /// <param name="trainName"></param>
        /// <param name="broker"></param>
        /// <exception cref="ArgumentException">Train.Name != <paramref name="commonProperties"/>.TrainName</exception>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">empty.</exception>
        internal DCTrain(DCMachine machine, DCParameters commonProperties, String trainName, EventBroker broker)
        {
            Name = trainName;

            if (!Name.Equals(commonProperties.Name))
                throw new ArgumentException("Train.Name != commonProperties.TrainName");

            if (!Name.Equals(machine.Name))
                throw new ArgumentException("Train.Name != machine.TrainName");
            Machine = machine;

        }
    }
}
