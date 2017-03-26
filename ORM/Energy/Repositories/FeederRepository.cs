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
        public static FeederRepository GetInstance()
        {
            return GetInstance<FeederRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// координаты и сопротивление фидеров (определенного типа) для выбранной подстанции
        /// </summary>
        /// <param name="powerSupplyStation"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IList<Feeder> GetFeeder(PowerSupplyStation powerSupplyStation, String name)
         {
            return GetAll()
                 .Where(feeder => feeder.PSS == powerSupplyStation)
                 .Where (feeder => feeder.Feeder_Type == name)
                 .Select(feeder => feeder).ToList();             
        }


    }
}
