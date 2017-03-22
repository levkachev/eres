using ORM.Base;
using NHibernate;
using ORM.Train.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace TrainMovement.Repositories
{
   public class Train_NameRepository : Repository<Train_Name>
    {
        public static Train_NameRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<Train_NameRepository>(factory);
        }

        public Train_Name GetByName(String name)
        {
            return GetAll()
                .Where(tname => tname.Name == name)
                .SingleOrDefault();
        }
    }
}
