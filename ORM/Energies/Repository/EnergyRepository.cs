using System;
using ORM.Base;
using ORM.Energies.Entities;
using ORM.Lines.Repository;

namespace ORM.Energies.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class EnergyRepository : Repository<PowerSupplyStation>
    {
        internal static EnergyRepository GetInstance() => GetInstance<EnergyRepository>(SessionWrapper.GetInstance().Factory);

        public static Entities.Energy GetPST(String lineName)
        {
           
            var repository = EnergyRepository.GetInstance();
            var line = LineRepository.GetInstance().GetIdByName(lineName);
            // var speedLimitRepository = SpeedLimitRepository.GetInstance();
            // var speedLimit = speedLimitRepository.GetAll(stageName);
            var powerSupplyStationRepository = PowerSupplyStationRepository.GetInstance();
            var psr = powerSupplyStationRepository.GetAllPST(line, "90");
            //tmpStage.SpeedLimit = speedLimit;
            var tmpEnergy = new Energies.Entities.Energy();
            tmpEnergy.NameLine = lineName;
            //  tmpEnergy.PowerSupplyStation = "88";
            tmpEnergy.Piketage = psr;

            var psList = powerSupplyStationRepository.GetPowerStations(line);

            return tmpEnergy;

            

        }

        public override PowerSupplyStation GetByName(String name)
        {
            throw new NotImplementedException();
        }
    }


}