using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Energies.Entities;

namespace ORM.Energies.Repository
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class UnitRepository : Repository<Unit>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static UnitRepository GetInstance() => GetInstance<UnitRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Unit GetByName(NamedUnit name) => GetAll().SingleOrDefault(unit => unit.NamedUnit == name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="powerSupplyStation"></param>
        /// <returns></returns>
        public IList<Unit> GetUnit(PowerSupplyStation powerSupplyStation) => GetAll().Where(unit => unit.PowerSupplyStation == powerSupplyStation).Select(unit => unit).ToList();

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override Unit GetByName(String name) => GetAll().SingleOrDefault(unit => unit.NamedUnit.Name == name);
    }
}
