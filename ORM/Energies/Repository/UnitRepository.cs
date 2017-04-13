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
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Unit GetByName(Unit_Name name)
        {
            return GetAll()
                .SingleOrDefault(unit => unit.Unit_Name == name);
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

