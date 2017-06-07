using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Energy.Entities;

namespace ORM.Energies.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class FeederRepository : Repository<Feeder>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
                 .Where(feeder => feeder.PowerSupplyStation == powerSupplyStation)
                 .Where (feeder => feeder.FeederType == name)
                 .Select(feeder => feeder).ToList();             
        }
    }
}
