using System;
using System.Linq;
using ORM.Base;
using ORM.Train.Entities;

namespace ORM.Trains.Repository.Trains
{
    /// <summary>
    /// 
    /// </summary>
    public class MassRepository : Repository<MassMass>
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static MassRepository GetInstance()
        {
            return GetInstance<MassRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public MassMass GetByMass(Double mass)
        {
            return GetAll()
                .SingleOrDefault(tmass => IsEqual(tmass.Mass, mass));
        }

        /// <summary>
        /// Возвращает истина, если два значения равны
        /// </summary>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        private static Boolean IsEqual(Double arg0, Double arg1)
        {
            return Math.Abs(arg0 - arg1) < Double.Epsilon;
        }
    }
}
