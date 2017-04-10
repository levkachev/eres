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
        public Guid GetIDByName(String name)
        {
            var tmp = GetAll()
                .SingleOrDefault(tr => tr.Name == name);
            if (tmp == null)
                throw new ArgumentOutOfRangeException(paramName: nameof(name));
            return tmp.ID;
        }

        public Motor_Type GetIDMotorTypeByName(String name)
        {
            var tmp = GetAll()
                .SingleOrDefault(tr => tr.Name == name);
            if (tmp == null)
                throw new ArgumentOutOfRangeException(paramName: nameof(name));
            return tmp.MotorType;
        }
    }
}
