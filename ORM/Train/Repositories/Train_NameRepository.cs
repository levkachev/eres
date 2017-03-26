using ORM.Base;
using NHibernate;
using ORM.Train.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ORM.Train.Repositories
{
   public class Train_NameRepository : Repository<Train_Name>
    {
        public static Train_NameRepository GetInstance()
        {
            return GetInstance<Train_NameRepository>(SessionWrapper.GetInstance().Factory);
        }

        public Train_Name GetByName(String name)
        {
            return GetAll()
                .Where(tname => tname.Name == name)
                .SingleOrDefault();
        }
    }
}
