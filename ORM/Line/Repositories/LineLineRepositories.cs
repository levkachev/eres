using ORM.Base;
using NHibernate;
using System.Linq;
using System.Collections.Generic;
using System;
using ORM.Line.Entities;

namespace ORM.Line.Repositories
{
    public class LineLineRepository : Repository<LineLine>

    {
        public static LineLineRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<LineLineRepository>(factory);
        }

       public LineLine GetLineId(Guid Id)
       {
           return GetById(Id);
       }
        public IList<String> GetLineNames()
        {
            return GetAll()
                .Select(s => s.Name)
                .ToList();
        }
        public LineLine GetByName(String name)
        {
            return GetAll()
                .Where(pstline => pstline.Name == name)
                .SingleOrDefault();
        }
        // public IList<PowerSupplyStation> GetName()
        // {
        //       return GetAll()
        //          .Where(b => String.Equals(b.Line.Name, "Калининская"))
        //           .SelectMany(x => x.Name)
        //          .ToList<PowerSupplyStation>();
    }
    
}
