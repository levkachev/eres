using TrainMovement.Machine;
using ORM.Train.Repositories;
using TrainMovement.Stuff;

namespace TrainMovement.Train
{
   
    public class TrainFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private static BaseMachine ACMachinePrototype = new ACMachine();

        /// <summary>
        /// 
        /// </summary>
        private static BaseMachine DCMachinePrototype = new DCMachine();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static BaseMachine GetNewACMachine()
        {
            return CloneMachine(ACMachinePrototype);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static BaseMachine GetNewDCMachine()
        {
            return CloneMachine(DCMachinePrototype);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        private static BaseMachine CloneMachine(BaseMachine machine)
        {
            return machine.DeepCopy();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Train GetACTrain()
        {
            return new Train(GetNewACMachine(), АdditionalParameterRepository.GetАdditionalParameter());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Train GetDCTrain()
        {
            return new Train(GetNewDCMachine(), АdditionalParameterRepository.GetАdditionalParameter());
        }

    }
}
