using System;
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
        public static BaseTrain GetACTrain(String trainName, EventBroker broker)
        {
            var machine = AdditionalParameterRepository.GetACMachineParametres(trainName);
            var train = AdditionalParameterRepository.GetACTrainParametres(trainName);
            return new ACTrain(machine, train, trainName, broker);
        }

        /// <summary>
        /// Создает DC поезд
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">less zero.</exception>
        public static BaseTrain GetDCTrain(String trainName, EventBroker broker)
        {
            var machine = AdditionalParameterRepository.GetDCMachineParametres(trainName);
            var train = AdditionalParameterRepository.GetDCTrainParameters(trainName);
            return new DCTrain(machine, train, trainName, broker);
        }
    }
}
