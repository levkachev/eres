using System;
using System.Linq;
using ORM.Base;
using ORM.Trains.Entities;

namespace ORM.Trains.Repository.Trains
{
    /// <summary>
    /// 
    /// </summary>
   public class MotorTypesRepository: Repository<MotorTypes>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MotorTypesRepository GetInstance()
        {
            return GetInstance<MotorTypesRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public MotorTypes GetByType(String type)
        {
            return GetAll()
                .SingleOrDefault(mt => mt.MotorType == type);
        }
    }
}
