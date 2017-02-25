using ORM.Base;
using NHibernate;
using ORM.Line.Entities;

namespace ORM.Line.Repositories
{
    public class LineRepository : Repository<Line.Entities.Line>

    {
        public LineRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<LineRepository>(factory);
        }
    }
}
