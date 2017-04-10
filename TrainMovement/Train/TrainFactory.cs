using TrainMovement.Machine;
using ORM.Train.Repositories;
using TrainMovement.Stuff;
using ORM.Train.Entities;
using System;

namespace TrainMovement.Train
{
   
    public class TrainFactory
    {
        /// <summary>
        /// 
        /// </summary>
       // private static BaseMachine ACMachinePrototype = new ACMachine();

        /// <summary>
        /// 
        /// </summary>
        private static BaseMachine DCMachinePrototype = new DCMachine();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //private static BaseMachine GetNewACMachine()
        //{
        //    return CloneMachine(ACMachinePrototype);
        //}

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
        public static BaseTrain GetACTrain(String trainName)
        {
            return new ACTrain(new ACMachine(trainName), АdditionalParameterRepository.GetACTrainParametres(trainName), trainName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static BaseTrain GetDCTrain(String trainName)
        {
            throw new NotImplementedException();
            //return new DCTrain(GetNewDCMachine(), АdditionalParameterRepository.GetDCTrainParametres(trainName), trainName);
        }

    }
}
