using System;
using System.Linq;
using ORM.Base;
using ORM.Train.Entities;
using ORM.Helpers;

namespace ORM.Trains.Repository
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
                .SingleOrDefault(tmass => MathHelper.IsEqual(tmass.Mass, mass));
        }

       
    }
}
