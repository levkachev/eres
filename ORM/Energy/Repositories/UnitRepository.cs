using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ORM.Energy.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitRepository : Repository<Unit>

    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static UnitRepository GetInstance()
        {
            return GetInstance<UnitRepository>(SessionWrapper.GetInstance().Factory);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Unit GetByName(Unit_Name name)
        {
            return GetAll()
                .Where(unit => unit.Unit_Name == name)
                .SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="powerSupplyStation"></param>
        /// <returns></returns>
        public IList<Unit> GetUnit(PowerSupplyStation powerSupplyStation)
        {
            return GetAll()
                 .Where(unit => unit.PowerSupplyStation == powerSupplyStation)
                 .Select(unit => unit).ToList();
        }
       
    }
}

