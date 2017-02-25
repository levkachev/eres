using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;

namespace ORM.Energy.Repositories
{
    public class ResistanceRepository : Repository<Resistance>

    {
        public static ResistanceRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<ResistanceRepository>(factory);
        }
    }
}
