using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;

namespace ORM.Energy.Repositories
{
    public class ResistanceRepository : Repository<Resistance>

    {
        public static ResistanceRepository GetInstance()
        {
            return GetInstance<ResistanceRepository>(SessionWrapper.GetInstance().Factory);
        }
    }
}
