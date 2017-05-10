using System;
using ORM.Stageis.Repository;
using ORM.Trains.Repository;

namespace TrainMovement.Train
{
    /// <summary>
    /// Фабрика поездов
    /// </summary>
    public class TrainFactory
    {
        /// <summary>
        /// Создает AC поезд
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">less zero.</exception>
        public static BaseTrain GetACTrain(String trainName,EventBroker broker)
        {
            return new ACTrain(АdditionalParameterRepository.GetACMachineParametres(trainName), АdditionalParameterRepository.GetACTrainParametres(trainName), trainName, broker);
        }

        /// <summary>
        /// Создает DC поезд
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">less zero.</exception>
        public static BaseTrain GetDCTrain(String trainName, EventBroker broker)
        {
            return new DCTrain(АdditionalParameterRepository.GetDCMachineParametres(trainName), АdditionalParameterRepository.GetDCTrainParametres(trainName), trainName, broker);
        }

    }
}
