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
    public class АdditionalParameterRepository : Repository<AdditionalParameter>
    {
        /// <summary>
        /// Создает экземляр репозиторий для дополнительных параметров
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        internal static АdditionalParameterRepository GetInstance() => GetInstance<АdditionalParameterRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// Достает из БД все записи из таблицы Дополнительные параметры
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        private static IList<AdditionalParameter> GetАdditionalParameter() => АdditionalParameterRepository.GetInstance().GetAll();

        /// <summary>
        /// Создает объект для AC поезда с дополнительными параметрами
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static ACParameters GetACTrainParametres(String trainName)
        {
            var repository = GetInstance();
            var baseTrainParameters = repository.GetTrainBaseParameters(trainName);
            var nbAuto = repository.GetAdditionalParametersByTrainName(trainName).nbAuto;
            var acTrainParameters = new ACParameters(baseTrainParameters, nbAuto);
            return acTrainParameters;
        }
        /// <summary>
        /// Создает объект для DC поезда с дополнительными параметрами 
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        public static DCParameters GetDCTrainParameters(String trainName) => GetInstance().GetTrainBaseParameters(trainName) as DCParameters;


        /// <summary>
        /// Создает объект для  AC двигателя
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static ACMachine GetACMachineParametres(String trainName)
        {
            #region Old code
            //var repository = GetInstance();

            //var baseMachine = repository.GetBaseMachineParameters(trainName);

            //var acMachine = baseMachine as ACMachine;
            //if (acMachine == null)
            //    throw new InvalidCastException();

            //acMachine.Umax = repository.GetAdditionalParametersByTrainName(trainName).Umax;
            //acMachine.Unominal = repository.GetAdditionalParametersByTrainName(trainName).Unom;

            // return acMachine;
            #endregion

            return new ACMachine(GetInstance().GetAdditionalParametersByTrainName(trainName));
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

            var baseMachine = repository.GetBaseMachineParameters(trainName);

            var dcMachine = (DCMachine)baseMachine;
            dcMachine.WeakPull2 = repository.GetAdditionalParametersByTrainName(trainName).WeakPull2;

            dcMachine.PositionPull2 = repository.GetAdditionalParametersByTrainName(trainName).PositionPull2;

            dcMachine.ConnectionPull2 = repository.GetAdditionalParametersByTrainName(trainName).ConnectionPull2;

            dcMachine.AssemblyPowerCircuitTime = repository.GetAdditionalParametersByTrainName(trainName).AssemblyPowerCircuitTime;

            dcMachine.DisassemblyPowerCircuitTime = repository.GetAdditionalParametersByTrainName(trainName).DisassemblyPowerCircuitTime;

            dcMachine.AssemblyPullTime = repository.GetAdditionalParametersByTrainName(trainName).AssemblyPullTime;

            dcMachine.AssemblyPullResistance = repository.GetAdditionalParametersByTrainName(trainName).AssemblyPullResistance;

            dcMachine.AssemblyBreakTime = repository.GetAdditionalParametersByTrainName(trainName).AssemblyBreakTime;

            dcMachine.AssemblyBreakResistance = repository.GetAdditionalParametersByTrainName(trainName).AssemblyBreakResistance;

            dcMachine.AnchorResistance = repository.GetAdditionalParametersByTrainName(trainName).AnchorResistance;

            dcMachine.MainPoleResistance = repository.GetAdditionalParametersByTrainName(trainName).MainPoleResistance;

            dcMachine.ComPolesResistance = repository.GetAdditionalParametersByTrainName(trainName).CompolesResistance;

            dcMachine.AutoModeFactor1 = repository.GetAdditionalParametersByTrainName(trainName).AutoModeFactor1;

            dcMachine.AutoModeFactor2 = repository.GetAdditionalParametersByTrainName(trainName).AutoModeFactor2;

            dcMachine.ExcitationTimeFactor1 = repository.GetAdditionalParametersByTrainName(trainName).ExcitationTimeFactor1;

            dcMachine.ExcitationTimeFactor2 = repository.GetAdditionalParametersByTrainName(trainName).ExcitationTimeFactor2;

            dcMachine.ExcitationTimeFactor3 = repository.GetAdditionalParametersByTrainName(trainName).ExcitationTimeFactor3;

            dcMachine.MaxExcitationTime = repository.GetAdditionalParametersByTrainName(trainName).MaxExcitationTime;

            dcMachine.LowAutoModeRange = repository.GetAdditionalParametersByTrainName(trainName).LowAutoModeRange;

            dcMachine.HighAutoModeRange = repository.GetAdditionalParametersByTrainName(trainName).HighAutoModeRange;

            dcMachine.LinearGrowCurrentTime = repository.GetAdditionalParametersByTrainName(trainName).LinearGrowCurrentTime;

            return dcMachine;
        }

        /// <summary>
        /// Создает объект для общего двигателя
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        private BaseMachine GetBaseMachineParameters(String trainName)
        {
            var assemblyPullTime = GetAdditionalParametersByTrainName(trainName).AssemblyPullTime;
            var disassemblyPowerCircuitTime = GetAdditionalParametersByTrainName(trainName).AssemblyBreakResistance;
            var assemblyBreakTime = GetAdditionalParametersByTrainName(trainName).AssemblyBreakTime;

            return new BaseMachine(disassemblyPowerCircuitTime, assemblyBreakTime, assemblyPullTime, trainName);
        }

        /// <summary>
        /// Создает объект для общего поезда  с дополнительными параметрами 
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        private BaseTrainParameters GetTrainBaseParameters(String trainName)
        {
            var carLength = GetAdditionalParametersByTrainName(trainName).CarLength;

            var unladenWeight = GetAdditionalParametersByTrainName(trainName).UnladenWeight;

            var numberCars = GetAdditionalParametersByTrainName(trainName).NumberCars;

            var breakAverage = GetAdditionalParametersByTrainName(trainName).BAverage;

            var netResistencePullFactor = GetAdditionalParametersByTrainName(trainName).NetResistencePullFactor;

            var aerodynamicDragFactor = GetAdditionalParametersByTrainName(trainName).AerodynamicDragFactor;

            var netResistenceCoastingFactor1 = GetAdditionalParametersByTrainName(trainName).NetResistanceCoastingFactor1;

            var netResistenceCoastingFactor2 = GetAdditionalParametersByTrainName(trainName).NetResistanceCoastingFactor2;

            var netResistenceCoastingFactor3 = GetAdditionalParametersByTrainName(trainName).NetResistanceCoastingFactor3;

            var trainEqvivalentSurface = GetAdditionalParametersByTrainName(trainName).TrainEquivalentSurface;

            var inertiaRotationFactor = GetAdditionalParametersByTrainName(trainName).InertiaRotationFactor;

            var ownNeedsElectricPower = GetAdditionalParametersByTrainName(trainName).OwnNeedsElectricPower;

            return new BaseTrainParameters (numberCars, carLength, unladenWeight, breakAverage, netResistencePullFactor, aerodynamicDragFactor, netResistenceCoastingFactor1, netResistenceCoastingFactor2, netResistenceCoastingFactor3, trainEqvivalentSurface, inertiaRotationFactor, ownNeedsElectricPower, trainName);

        }

        /// <summary>
        /// Достает из БД все дополнительные параметры по имени поезда
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        private AdditionalParameter GetAdditionalParametersByTrainName(String trainName) => 
            GetAll().SingleOrDefault(baseTrain => baseTrain.TrainName.Name == trainName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override AdditionalParameter GetByName(String name)
        {
            throw new NotImplementedException();
        }
    }
}
