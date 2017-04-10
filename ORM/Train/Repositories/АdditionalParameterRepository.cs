using ORM.Base;
using ORM.Train.Entities;
using System.Linq;
using System;


namespace ORM.Train.Repositories
{
    public class АdditionalParameterRepository : Repository<АdditionalParameter>
    {
        internal static АdditionalParameterRepository GetInstance()
        {
            return GetInstance<АdditionalParameterRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static АdditionalParameter GetАdditionalParameter()
        {
            var repository = АdditionalParameterRepository.GetInstance();
            return repository.GetAll().FirstOrDefault();
        }

        public static ACTrainParametres GetACTrainParametres(String trainName)
        {
            var repository = АdditionalParameterRepository.GetInstance();

            var baseParametres = repository.GetBaseTrainParametres(trainName);

            var acTrainParametres = (ACTrainParametres)baseParametres;

            acTrainParametres.NBAuto = repository.GetSpecialACTrainParametres(trainName);
            
            return acTrainParametres;
        }

        public static DCTrainParametres GetDCTrainParametres(String trainName)
        {
            var repository = АdditionalParameterRepository.GetInstance();

            var baseParametres = repository.GetBaseTrainParametres(trainName);

            var dcTrainParametres = (DCTrainParametres)baseParametres;

            //это заглушка. Дописать все свойства!

            return dcTrainParametres;
        }

        private ACMachineParametres GetACMachineParametres(String trainName)
        {
            var repository = АdditionalParameterRepository.GetInstance();

            var baseMachine = repository.GetBaseMachineParametres(trainName);

            var acMachine = (ACMachineParametres)baseMachine;

            acMachine.Umax = repository.GetParametresForTrain(trainName).Umax;

            return acMachine;

        }

        private MachineBaseParametres GetBaseMachineParametres(String trainName)
        {
            var assemblyPullTime = GetParametresForTrain(trainName).AssemblyPullTime;
            return new MachineBaseParametres(assemblyPullTime);
        }

        private BaseTrainParametres GetBaseTrainParametres(String trainName)
        {
            var carLength = GetParametresForTrain(trainName).CarLength;

            var unladenWeight = GetParametresForTrain(trainName).UnladenWeight;

            var numberCars = GetParametresForTrain(trainName).NumberCars;

            var breakAverage = GetParametresForTrain(trainName).NumberCars;

            var netResistencePullFactor = GetParametresForTrain(trainName).NetResistencePullFactor;

            var aerodynamicDragFactor = GetParametresForTrain(trainName).AerodynamicDragFactor;

            var netResistenceCoastingFactor1 = GetParametresForTrain(trainName).NetResistenceCoastingFactor1;

            var netResistenceCoastingFactor2 = GetParametresForTrain(trainName).NetResistenceCoastingFactor2;

            var netResistenceCoastingFactor3 = GetParametresForTrain(trainName).NetResistenceCoastingFactor3;

            var trainEqvivalentSurface = GetParametresForTrain(trainName).TrainEqvivalentSurface;

            var inertiaRotationFactor = GetParametresForTrain(trainName).InertiaRotationFactor;

            var ownNeedsElectricPower = GetParametresForTrain(trainName).OwnNeedsElectricPower;

            return new BaseTrainParametres(numberCars, carLength, unladenWeight, breakAverage, netResistencePullFactor, aerodynamicDragFactor, netResistenceCoastingFactor1, netResistenceCoastingFactor2, netResistenceCoastingFactor3, trainEqvivalentSurface, inertiaRotationFactor, ownNeedsElectricPower);

        }

        private Int32 GetSpecialACTrainParametres(String trainName)
        {
            return GetParametresForTrain(trainName).nbAuto;
        }

        private Double GetUmaxACMachineParametres(String trainName)
        {
            return GetParametresForTrain(trainName).Umax;
        }

        private АdditionalParameter GetParametresForTrain(String trainName)
        {
            return GetAll()
              .Where(basetrain => basetrain.TrainName.Name == trainName)
              .SingleOrDefault();
        }
    }
}
