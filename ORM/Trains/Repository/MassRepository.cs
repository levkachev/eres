using System;
using System.Linq;
using ORM.Base;
using ORM.Trains.Entities;
using ORM.OldHelpers;

namespace ORM.Trains.Repository
{
    /// <inheritdoc />
    /// <summary>
    /// Хранилище масс.
    /// </summary>
    public class MassRepository : Repository<Mass>
    {
        /// <summary>
        /// Получение экземпляра хранилища.
        /// </summary>
        /// <returns></returns>
        public static MassRepository GetInstance() => GetInstance<MassRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// Получение объекта записи о массе поезда по её величине.
        /// </summary>
        /// <param name="mass"></param>
        /// <returns>Объект или <see langword="null"/></returns>
        public Mass GetByMass(Double mass) => GetAll().SingleOrDefault(x => x.Value.IsEqual(mass));

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override Mass GetByName(String name)
        {
            throw new NotImplementedException();
        }
    }
}
