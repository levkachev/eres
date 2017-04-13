using System;
using System.Linq;
using ORM.Base;
using ORM.Train.Entities;

namespace ORM.Trains.Repository.Trains
{
    /// <summary>
    /// 
    /// </summary>
   public class MotorTypeRepository: Repository<Motor_Type>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MotorTypeRepository GetInstance()
        {
            return GetInstance<MotorTypeRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Motor_Type GetByType(String type)
        {
            return GetAll()
                .SingleOrDefault(mt => mt.MotorType == type);
        }
    }
}
