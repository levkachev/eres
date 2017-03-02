using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ORM.Energy.Repositories
{
    public class FeederRepository : Repository<Feeder>

    {
        public static FeederRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<FeederRepository>(factory);
        }

        
        public IList<String> GetFeeder(PowerSupplyStation powerSupplyStation)
         {
            return GetAll()
                 .Where(feeder => feeder.PSS == powerSupplyStation).Select(feeder => feeder.Name)
                 .ToList();             
        }
    }
}
