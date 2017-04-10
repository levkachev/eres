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
        public static LineLineRepository GetInstance()
        {
            return GetInstance<LineLineRepository>(SessionWrapper.GetInstance().Factory);
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
        public Guid GetIDByName(String name)
        {
            var tmp = GetAll()
                .SingleOrDefault(tr => tr.Name == name);
            if (tmp == null)
                throw new ArgumentOutOfRangeException(paramName: nameof(name));
            return tmp.ID;
        }

    }
    
}
