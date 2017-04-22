using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Machine;
using ORM.Trains.Repository.Trains;

namespace ORM.Trains.Repository
{
    /// <summary>
    /// Класс для создания объектов двигателя и поезда
    /// </summary>
    public class АdditionalParameterRepository : Repository<АdditionalParameter>
    {
        /// <summary>
        /// Создает экземляр репозиторий для дополнительных параметров
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        internal static АdditionalParameterRepository GetInstance()
        {
            return GetInstance<АdditionalParameterRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// Достает из БД все записи из таблицы Дополнительные параметры
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        private static IList<АdditionalParameter> GetАdditionalParameter() => АdditionalParameterRepository.GetInstance().GetAll();

        /// <summary>
        /// Создает объект для AC поезда с дополнительными параметрами
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        public static ACParametres GetACTrainParametres(String trainName)
        {
            var repository = АdditionalParameterRepository.GetInstance();

            var baseParametres = repository.GetTrainBaseParametres(trainName);

            var acTrainParametres = (ACParametres)baseParametres;

            acTrainParametres.NBAuto = repository.GetAdditionalParametresByTrainName(trainName).nbAuto;

            return acTrainParametres;
        }
        /// <summary>
        /// Создает объект для DC поезда с дополнительными параметрами 
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        public static DCParametres GetDCTrainParametres(String trainName)
        {
            var repository = АdditionalParameterRepository.GetInstance();

            var baseParametres = repository.GetTrainBaseParametres(trainName);

            var dcTrainParametres = (DCParametres)baseParametres;

           

            return dcTrainParametres;
        }
         
           
          

        /// <summary>
        /// Создает объект для  AC двигателя
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">less zero.</exception>
        public static ACMachine GetACMachineParametres(String trainName)
        {
            var repository = АdditionalParameterRepository.GetInstance();

            var baseMachine = repository.GetBaseMachineParametres(trainName);

            var acMachine = (ACMachine)baseMachine;

            acMachine.Umax = repository.GetAdditionalParametresByTrainName(trainName).Umax;
            acMachine.Unominal = repository.GetAdditionalParametresByTrainName(trainName).Unom;

            return acMachine;

        }

        /// <summary>
        /// Создает объект для  DC двигателя (Не сделан!)
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">less zero.</exception>
        public static DCMachine GetDCMachineParametres(String trainName)
        {
            var repository = АdditionalParameterRepository.GetInstance();

            var baseMachine = repository.GetBaseMachineParametres(trainName);

            var dcMachine = (DCMachine)baseMachine;
            dcMachine.WeakPull2 = repository.GetAdditionalParametresByTrainName(trainName).WeakPull2;

            dcMachine.PositionPull2 = repository.GetAdditionalParametresByTrainName(trainName).PositionPull2;

            dcMachine.ConnectionPull2 = repository.GetAdditionalParametresByTrainName(trainName).ConnectionPull2;

            dcMachine.AssemblyPowerCircuitTime = repository.GetAdditionalParametresByTrainName(trainName).AssemblyPowerCircuitTime;

            dcMachine.DisassemblyPowerCircuitTime = repository.GetAdditionalParametresByTrainName(trainName).DisassemblyPowerCircuitTime;

            dcMachine.AssemblyPullTime = repository.GetAdditionalParametresByTrainName(trainName).AssemblyPullTime;

            dcMachine.AssemblyPullResistance = repository.GetAdditionalParametresByTrainName(trainName).AssemblyPullResistance;

            dcMachine.AssemblyBreakTime = repository.GetAdditionalParametresByTrainName(trainName).AssemblyBreakTime;

            dcMachine.AssemblyBreakResistance = repository.GetAdditionalParametresByTrainName(trainName).AssemblyBreakResistance;

            dcMachine.AnchorResistance = repository.GetAdditionalParametresByTrainName(trainName).AnchorResistance;

            dcMachine.MainPoleResistance = repository.GetAdditionalParametresByTrainName(trainName).MainPoleResistance;

            dcMachine.ComPolesResistance = repository.GetAdditionalParametresByTrainName(trainName).CompolesResistance;

            dcMachine.AutoModeFactor1 = repository.GetAdditionalParametresByTrainName(trainName).AutomodeFactor1;

            dcMachine.AutoModeFactor2 = repository.GetAdditionalParametresByTrainName(trainName).AutomodeFactor2;

            dcMachine.ExcitationTimeFactor1 = repository.GetAdditionalParametresByTrainName(trainName).ExcitationTimeFactor1;

            dcMachine.ExcitationTimeFactor2 = repository.GetAdditionalParametresByTrainName(trainName).ExcitationTimeFactor2;

            dcMachine.ExcitationTimeFactor3 = repository.GetAdditionalParametresByTrainName(trainName).ExcitationTimeFactor3;

            dcMachine.MaxExcitationTime = repository.GetAdditionalParametresByTrainName(trainName).MaxExcitationTime;

            dcMachine.LowAutoModeRange = repository.GetAdditionalParametresByTrainName(trainName).LowAutoModeRange;

            dcMachine.HighAutoModeRange = repository.GetAdditionalParametresByTrainName(trainName).HighAutoModeRange;

            dcMachine.LinearGrowCurrentTime = repository.GetAdditionalParametresByTrainName(trainName).LinearGrowCurrentTime;

            return dcMachine;

        }

        /// <summary>
        /// Создает объект для общего двигателя
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        private BaseMachine GetBaseMachineParametres(String trainName)
        {
            var assemblyPullTime = GetAdditionalParametresByTrainName(trainName).AssemblyPullTime;
            var disassemblyPowerCircuitTime = GetAdditionalParametresByTrainName(trainName).AssemblyBreakResistance;
            var assemblyBreakTime = GetAdditionalParametresByTrainName(trainName).AssemblyBreakTime;
            return new BaseMachine (assemblyPullTime, assemblyBreakTime, assemblyPullTime, trainName);
        }

        /// <summary>
        /// Создает объект для общего поезда  с дополнительными параметрами 
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        private BaseTrainParametres GetTrainBaseParametres(String trainName)
        {
            var carLength = GetAdditionalParametresByTrainName(trainName).CarLength;

            var unladenWeight = GetAdditionalParametresByTrainName(trainName).UnladenWeight;

            var numberCars = GetAdditionalParametresByTrainName(trainName).NumberCars;

            var breakAverage = GetAdditionalParametresByTrainName(trainName).NumberCars;

            var netResistencePullFactor = GetAdditionalParametresByTrainName(trainName).NetResistencePullFactor;

            var aerodynamicDragFactor = GetAdditionalParametresByTrainName(trainName).AerodynamicDragFactor;

            var netResistenceCoastingFactor1 = GetAdditionalParametresByTrainName(trainName).NetResistenceCoastingFactor1;

            var netResistenceCoastingFactor2 = GetAdditionalParametresByTrainName(trainName).NetResistenceCoastingFactor2;

            var netResistenceCoastingFactor3 = GetAdditionalParametresByTrainName(trainName).NetResistenceCoastingFactor3;

            var trainEqvivalentSurface = GetAdditionalParametresByTrainName(trainName).TrainEqvivalentSurface;

            var inertiaRotationFactor = GetAdditionalParametresByTrainName(trainName).InertiaRotationFactor;

            var ownNeedsElectricPower = GetAdditionalParametresByTrainName(trainName).OwnNeedsElectricPower;

            return new BaseTrainParametres (numberCars, carLength, unladenWeight, breakAverage, netResistencePullFactor, aerodynamicDragFactor, netResistenceCoastingFactor1, netResistenceCoastingFactor2, netResistenceCoastingFactor3, trainEqvivalentSurface, inertiaRotationFactor, ownNeedsElectricPower);

        }

        /// <summary>
        /// Достает из БД все дополнительные параметры по имени поезда
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        private АdditionalParameter GetAdditionalParametresByTrainName(String trainName)
        {
            return GetAll()
              .SingleOrDefault(baseTrain => baseTrain.TrainName.Name == trainName);
        }
    }
}
