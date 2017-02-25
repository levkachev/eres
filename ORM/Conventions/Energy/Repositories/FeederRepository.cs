using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;

namespace ORM.Energy.Repositories
{
    public class FeederRepository : Repository<Unit>

    {
        public static FeederRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<FeederRepository>(factory);
        }
    }
}
