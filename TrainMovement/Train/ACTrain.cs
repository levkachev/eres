using System;
using TrainMovement.Machine;
using ORM.Train.Entities;

namespace TrainMovement.Train
{
    public class ACTrain : BaseTrain
    {
        private Int32 nbAuto;

        public Int32 NbAuto
        {
            get { return nbAuto; }
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                nbAuto = value;
            }
        }

        public ACTrain(ACMachine machine, ACTrainParametres commonProperties, String trainName)
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
