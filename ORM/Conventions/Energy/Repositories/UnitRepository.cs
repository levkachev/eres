using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;

namespace ORM.Energy.Repositories
{
    public class UnitRepository : Repository<Unit>

    {
        public static UnitRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<UnitRepository>(factory);
        }
    }
}

