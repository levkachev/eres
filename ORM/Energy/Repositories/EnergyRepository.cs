using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;
using System.Linq;
using System.Collections.Generic;
using System;
using ORM.Line.Entities;
using ORM.Line.Repositories;


namespace ORM.Energy.Repositories
{
    public class EnergyRepository : Repository<PowerSupplyStation>
    {
        internal static EnergyRepository GetInstance()
        {
            return GetInstance<EnergyRepository>((SessionWrapper.GetInstance().Factory));
        }

        public static EnergyEnergy GetPST(String lineName)
        {
           
            var repository = EnergyRepository.GetInstance();
            var linelineRepository = LineLineRepository.GetInstance();
            var line = linelineRepository.GetIDByName(lineName);
            // var speedLimitRepository = SpeedLimitRepository.GetInstance();
            // var speedLimit = speedLimitRepository.GetAll(stageName);
            var powerSupplyStationRepository = PowerSupplyStationRepository.GetInstance();
            var psr = powerSupplyStationRepository.GetAllPST(line, "90");
            //tmpStage.SpeedLimit = speedLimit;
            var tmpEnergy = new EnergyEnergy();
            tmpEnergy.NameLine = lineName;
            //  tmpEnergy.PowerSupplyStation = "88";
            tmpEnergy.Piketag = psr;

            return tmpEnergy;

            

        }
    }


}