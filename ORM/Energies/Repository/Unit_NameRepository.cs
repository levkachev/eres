using System;
using System.Linq;
using ORM.Base;
using ORM.Energy.Entities;

namespace ORM.Energies.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class Unit_NameRepository : Repository<Unit_Name>

    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static Unit_NameRepository GetInstance()
        {
            return GetInstance<Unit_NameRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Unit_Name GetByName(String name)
        {
            return GetAll()
                .SingleOrDefault(unit => unit.Name == name);
        }
    }
}
