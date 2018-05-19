using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Trains.Entities;
using ORM.Trains.Interpolation.Entities;
using ORM.Trains.Repository.Trains;

namespace ORM.Trains.Repository.Interpolation
{
    /// <inheritdoc />
    /// <summary>
    /// Хранилище тяговых и скоростных характеристик
    /// </summary>
    public class ElectricTractionCharacteristicsRepository : Repository<ElectricTractionCharacteristics>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ElectricTractionCharacteristicsRepository GetInstance() => 
            GetInstance<ElectricTractionCharacteristicsRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainName"></param>
        /// <param name="motorControl"></param>
        /// <param name="mass"></param>
        /// <returns></returns>
        public IEnumerable<ElectricTractionCharacteristics> GetCharacteristics(String trainName, ModeControl motorControl, Mass mass) => 
            GetAll().Where(characteristic => characteristic.Train.Name == trainName && characteristic.ModeControl == motorControl && characteristic.Mass == mass).ToList();

        public static IEnumerable<ElectricTractionCharacteristics> GetVfiRusi4(Mass mass, String modeControlName)
        {
            var modeControl = ModeControlRepository.GetInstance().GetByName(modeControlName);
            const String trainName = "81-740.1(Rusi4)";
            return GetInstance().GetCharacteristics(trainName, modeControl, mass);
        }

        /// <summary>
        /// Pull1
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static IEnumerable<ElectricTractionCharacteristics> GetVfiRusi4Pull1(Mass mass)
        {
            var modeControlsRepository = ModeControlRepository.GetInstance();
            var modeControl = modeControlsRepository.GetByName("Pull1");
            const String trainName = "81-740.1(Rusi4)";
            var vfiRepository = GetInstance();

            return vfiRepository.GetCharacteristics(trainName, modeControl, mass);
        }

        /// <summary>
        /// Pull2
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static IEnumerable<ElectricTractionCharacteristics> GetVfiRusi4Pull2(Mass mass)
        {
            var modecontrolRepository = ModeControlRepository.GetInstance();
            var modecontrol = modecontrolRepository.GetByName("Pull2");
            const String trainName = "81-740.1(Rusi4)";
            var vfiRepository = GetInstance();

            return vfiRepository.GetCharacteristics(trainName, modecontrol, mass);
        }

        /// <summary>
        /// Pull3
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static IEnumerable<ElectricTractionCharacteristics> GetVfiRusi4Pull3(Mass mass)
        {
            var modecontrolRepository = ModeControlRepository.GetInstance();
            var modecontrol = modecontrolRepository.GetByName("Pull3");
            const String trainName = "81-740.1(Rusi4)";
            var vfiRepository = GetInstance();

            return vfiRepository.GetCharacteristics(trainName, modecontrol, mass);
        }

        /// <summary>
        /// Pull4
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static IEnumerable<ElectricTractionCharacteristics> GetVfiRusi4Pull4(Mass mass)
        {
            var modecontrolRepository = ModeControlRepository.GetInstance();
            var modecontrol = modecontrolRepository.GetByName("Pull4");
            const String trainName = "81-740.1(Rusi4)";
            var vfiRepository = GetInstance();

            return vfiRepository.GetCharacteristics(trainName, modecontrol, mass);
        }
        
        /// <summary>
        /// Break1
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static IEnumerable<ElectricTractionCharacteristics> GetVfiRusi4Break1(Mass mass)
        {
            var modecontrolRepository = ModeControlRepository.GetInstance();
            var modecontrol = modecontrolRepository.GetByName("Break1");
            const String trainName = "81-740.1(Rusi4)";
            var vfiRepository = GetInstance();

            return vfiRepository.GetCharacteristics(trainName, modecontrol, mass);
        }

        /// <summary>
        /// Break2
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static IEnumerable<ElectricTractionCharacteristics> GetVfiRusi4Break2(Mass mass)
        {
            var modecontrolRepository = ModeControlRepository.GetInstance();
            var modecontrol = modecontrolRepository.GetByName("Break2");
            const String trainName = "81-740.1(Rusi4)";
            var vfiRepository = GetInstance();

            return vfiRepository.GetCharacteristics(trainName, modecontrol, mass);
        }

        /// <summary>
        /// Break3
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static IEnumerable<ElectricTractionCharacteristics> GetVfiRusi4Break3(Mass mass)
        {
            var modecontrolRepository = ModeControlRepository.GetInstance();
            var modecontrol = modecontrolRepository.GetByName("Break3");
            const String trainName = "81-740.1(Rusi4)";
            var vfiRepository = GetInstance();

            return vfiRepository.GetCharacteristics(trainName, modecontrol, mass);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override ElectricTractionCharacteristics GetByName(String name)
        {
            throw new NotImplementedException();
        }
    }
}
