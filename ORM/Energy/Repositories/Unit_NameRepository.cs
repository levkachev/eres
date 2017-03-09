using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;
using System.Linq;
using System.Collections.Generic;
using System;


namespace ORM.Energy.Repositories
{
    public class Unit_NameRepository : Repository<Unit_Name>

    {
        public static Unit_NameRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<Unit_NameRepository>(factory);
        }
        public Unit_Name GetByName(String name)
        {
            return GetAll()
                .Where(unit => unit.Name == name)
                .SingleOrDefault();
        }
    }
}
