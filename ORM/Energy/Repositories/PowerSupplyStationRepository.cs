using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;
using System.Linq;
using System.Collections.Generic;
using System;


namespace ORM.Energy.Repositories
{
    public class PowerSupplyStationRepository : Repository<PowerSupplyStation>
    
    {
       public static PowerSupplyStationRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<PowerSupplyStationRepository>(factory);
        }

        /// public IList<Name> GetPowerSupplyStation()
        /// {
        //     return GetAll()
        //         .Where(b => String.Equals(b.Line.Name, "Калининская" ))
        //        .Select(x => x.Name)
        //       .ToList<Name>();
        //  }

        public PowerSupplyStation GetPowerSupplyStation(String PowerSupplyStationName)
        {
            return GetAll()
                .SingleOrDefault(s => s.Name == PowerSupplyStationName);
        }
        public IList<String> GetPowerSupplyStationNames()
        {
            return GetAll()
                .Select(s => s.Name)
                .ToList();
        }
    }
}
