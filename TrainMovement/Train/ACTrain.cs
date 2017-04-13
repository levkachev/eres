using System;
using ORM.Train.Entities;
using ORM.Trains.Repository.Machine;

namespace TrainMovement.Train
{
    /// <summary>
    /// 
    /// </summary>
    public class ACTrain : BaseTrain
    {
        /// <summary>
        /// 
        /// </summary>
        private Int32 nbAuto;

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Int32 NbAuto
        {
            get { return nbAuto; }
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                nbAuto = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="commonProperties"></param>
        /// <param name="trainName"></param>
        /// <exception cref="ArgumentException">Train.Name != <paramref name="commonProperties"/>.TrainName</exception>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">empty.</exception>
        internal ACTrain(ACMachine machine, ACParametres commonProperties, String trainName)
        {
            Name = trainName;
            
            if (!Name.Equals(commonProperties.Name))
                throw new ArgumentException("Train.Name != commonProperties.TrainName");
            NbAuto = commonProperties.NBAuto;

            if (!Name.Equals(machine.Name))
                throw new ArgumentException("Train.Name != machine.TrainName");
            Machine = machine;
            
        }
    }
}
