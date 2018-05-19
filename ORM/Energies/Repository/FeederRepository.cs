using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Energies.Entities;


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
        public static FeederRepository GetInstance() => GetInstance<FeederRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// координаты и сопротивление фидеров (определенного типа) для выбранной подстанции
        /// </summary>
        /// <param name="powerSupplyStation"></param>
        /// <param name="feederTypeName"></param>
        /// <returns></returns>
        public IList<Feeder> GetFeeder(PowerSupplyStation powerSupplyStation, String feederTypeName) => 
            GetAll().Where(feeder => feeder.PowerSupplyStation == powerSupplyStation && feeder.FeederType == feederTypeName).Select(feeder => feeder).ToList();

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="feederName">Наименование фидера.</param>
        /// <returns></returns>
        public override Feeder GetByName(String feederName) => GetAll().SingleOrDefault(feeder => feeder.Name == feederName);
    }
}
