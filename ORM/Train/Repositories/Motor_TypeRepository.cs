using ORM.Base;
using NHibernate;
using ORM.Train.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ORM.Train.Repositories
{
   public class Motor_TypeRepository: Repository<Motor_Type>
    {
        public static Motor_TypeRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<Motor_TypeRepository>(factory);
        }

        public Motor_Type GetByType(String type)
        {
            return GetAll()
                .Where(mt => mt.MotorType == type)
                .SingleOrDefault();
        }
    }
}
