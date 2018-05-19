using System;
using System.Linq;
using ORM.Base;
using ORM.Energies.Entities;

namespace ORM.Energies.Repository
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class NamedUnitRepository : Repository<NamedUnit>
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static NamedUnitRepository GetInstance() => GetInstance<NamedUnitRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public override NamedUnit GetByName(String name) => GetAll().SingleOrDefault(unit => unit.Name == name);
    }
}
