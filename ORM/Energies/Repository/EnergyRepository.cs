using System;
using ORM.Base;
using ORM.Energy.Entities;
using ORM.Lines.Repository;

namespace ORM.Energies.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class EnergyRepository : Repository<PowerSupplyStation>
    {
        internal static EnergyRepository GetInstance()
        {
            return GetInstance<EnergyRepository>((SessionWrapper.GetInstance().Factory));
        }

        public static EnergyEnergy GetPST(String lineName)
        {
           
            var repository = EnergyRepository.GetInstance();
            var linelineRepository = LineRepository.GetInstance();
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

            var psList = powerSupplyStationRepository.GetPowerStations(line);

            return tmpEnergy;

            

        }
    }


}