using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Machine;

namespace ORM.Trains.Repository
{
    /// <inheritdoc />
    /// <summary>
    /// Класс для создания объектов двигателя и поезда
    /// </summary>
    public class AdditionalParameterRepository : Repository<AdditionalParameter>
    {
        /// <summary>
        /// Создает экземляр репозиторий для дополнительных параметров
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        internal static AdditionalParameterRepository GetInstance() => GetInstance<AdditionalParameterRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// Достает из БД все записи из таблицы Дополнительные параметрыs
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        private static IList<AdditionalParameter> GetAdditionalParameter() => GetInstance().GetAll();

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
            return new ACParameters(baseTrainParameters, nbAuto);
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
            var repository = GetInstance();
            var additionalParameter = repository.GetAdditionalParametersByTrainName(trainName);
            var baseMachine = repository.GetBaseMachineParameters(trainName);
            var dcMachine = (DCMachine) baseMachine;

            dcMachine.WeakPull2 = additionalParameter.WeakPull2;

            dcMachine.PositionPull2 = additionalParameter.PositionPull2;

            dcMachine.ConnectionPull2 = additionalParameter.ConnectionPull2;

            dcMachine.AssemblyPowerCircuitTime = additionalParameter.AssemblyPowerCircuitTime;

            dcMachine.DisassemblyPowerCircuitTime = additionalParameter.DisassemblyPowerCircuitTime;

            dcMachine.AssemblyPullTime = additionalParameter.AssemblyPullTime;

            dcMachine.AssemblyPullResistance = additionalParameter.AssemblyPullResistance;

            dcMachine.AssemblyBreakTime = additionalParameter.AssemblyBreakTime;

            dcMachine.AssemblyBreakResistance = additionalParameter.AssemblyBreakResistance;

            dcMachine.AnchorResistance = additionalParameter.AnchorResistance;

            dcMachine.MainPoleResistance = additionalParameter.MainPoleResistance;

            dcMachine.ComPolesResistance = additionalParameter.CompolesResistance;

            dcMachine.AutoModeFactor1 = additionalParameter.AutoModeFactor1;

            dcMachine.AutoModeFactor2 = additionalParameter.AutoModeFactor2;

            dcMachine.ExcitationTimeFactor1 = additionalParameter.ExcitationTimeFactor1;

            dcMachine.ExcitationTimeFactor2 = additionalParameter.ExcitationTimeFactor2;

            dcMachine.ExcitationTimeFactor3 = additionalParameter.ExcitationTimeFactor3;

            dcMachine.MaxExcitationTime = additionalParameter.MaxExcitationTime;

            dcMachine.LowAutoModeRange = additionalParameter.LowAutoModeRange;

            dcMachine.HighAutoModeRange = additionalParameter.HighAutoModeRange;

            dcMachine.LinearGrowCurrentTime = additionalParameter.LinearGrowCurrentTime;

            return dcMachine;
        }

        /// <summary>
        /// Создает объект для общего двигателя
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        private BaseMachine GetBaseMachineParameters(String trainName)
        {
            var additionalParameters = GetAdditionalParametersByTrainName(trainName);
            var assemblyPullTime = additionalParameters.AssemblyPullTime;
            var disassemblyPowerCircuitTime = additionalParameters.AssemblyBreakResistance;
            var assemblyBreakTime = additionalParameters.AssemblyBreakTime;
            return new BaseMachine(disassemblyPowerCircuitTime, assemblyBreakTime, assemblyPullTime, trainName);
        }

        /// <summary>
        /// Создает объект для общего поезда  с дополнительными параметрами 
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        private BaseTrainParameters GetTrainBaseParameters(String trainName) => new BaseTrainParameters(GetAdditionalParametersByTrainName(trainName));

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
