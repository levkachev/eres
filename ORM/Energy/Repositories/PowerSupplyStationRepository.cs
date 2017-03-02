using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;
using System.Linq;
using System.Collections.Generic;
using System;
using ORM.Line.Entities;



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

        public PowerSupplyStation GetPowerSupplyStationId(Guid Id)
        {
            return GetById(Id);
        }

        public PowerSupplyStation GetByName(String name)
        {
            return GetAll()
                .Where(pst => pst.Name == name)
                .SingleOrDefault();
        }
        //   public IList<String> GetPowerSupplyStation(LineLine lineline)
        //  {
        //    return GetAll()
        //         .Where(p => p.LineLine == lineline.ID);
        //       .Select(p => p.Name)
        //      .ToList<String>();
        // }

        public PowerSupplyStation GetPSTbyLine(LineLine line, String name)
        {
            return GetAll()
                .Where(pst => pst.Line == line)
                .Where(pst => pst.Name == name)
                .SingleOrDefault();
               
        }

    }
}
