using ORM.Train.Repositories;
using System;

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
        public static BaseTrain GetACTrain(String trainName)
        {
            return new ACTrain(АdditionalParameterRepository.GetACMachineParametres(trainName), АdditionalParameterRepository.GetACTrainParametres(trainName), trainName);
        }

        /// <summary>
        /// Создает DC поезд
        /// </summary>
        /// <returns></returns>
        public static BaseTrain GetDCTrain(String trainName)
        {
            return new DCTrain(АdditionalParameterRepository.GetDCMachineParametres(trainName), АdditionalParameterRepository.GetDCTrainParametres(trainName), trainName);
        }

    }
}
