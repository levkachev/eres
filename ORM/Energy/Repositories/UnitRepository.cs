using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ORM.Energy.Repositories
{
    public class UnitRepository : Repository<Unit>

    {
        public static UnitRepository GetInstance()
        {
            return GetInstance<UnitRepository>(SessionWrapper.GetInstance().Factory);
        }
        public Unit GetByName(Unit_Name name)
        {
            return GetAll()
                .Where(unit => unit.Unit_Name == name)
                .SingleOrDefault();
        }
        public IList<Unit> GetUnit(PowerSupplyStation powerSupplyStation)
        {
            return GetAll()
                 .Where(unit => unit.PSS == powerSupplyStation)
                 .Select(unit => unit).ToList();
        }
       
    }
}

