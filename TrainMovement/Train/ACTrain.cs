using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Machine;
using ORM.Trains.Repository.Trains;

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
            get => nbAuto;
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
        /// <param name="broker"></param>
        /// <exception cref="ArgumentException">Train.Name != <paramref name="commonProperties"/>.TrainName</exception>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">empty.</exception>
        internal ACTrain(ACMachine machine, ACParameters commonProperties, String trainName, EventBroker broker) 
            : base (machine, commonProperties, broker)
        {
            if (!trainName.Equals(commonProperties.Name))
                throw new ArgumentException("Train.Name != commonProperties.TrainName");

            Name = trainName;
            NbAuto = commonProperties.NBAuto;


            //var massObj = ORM.Trains.Repository.MassRepository.GetInstance().GetByMass(Mass);
            //var breakAverage = Interpolation.Rusi4.BreakAverage.GetInstance(massObj);

            //ModeControls.Add(Interpolation.Rusi4.Inert.GetInstance(massObj));
            //ModeControls.Add(breakAverage);



            //if (!Name.Equals(machine.Name))
            //    throw new ArgumentException("Train.Name != machine.TrainName");
            //Machine = machine;

            //Broker = broker;
        }
    }
}
