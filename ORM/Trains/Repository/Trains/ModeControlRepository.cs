using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Trains.Entities;

namespace ORM.Trains.Repository.Trains
{
    /// <inheritdoc />
    /// <summary>
    /// Хранилище режимов управления.
    /// </summary>
    public class ModeControlRepository : Repository<ModeControl>
    {
        /// <summary>
        /// Метод получения доступа к объекту, реализующему тип.
        /// </summary>
        /// <returns></returns>
        public static ModeControlRepository GetInstance() => GetInstance<ModeControlRepository>(SessionWrapper.GetInstance().Factory);

        /// <inheritdoc />
        /// <summary>
        /// Метод, извлекающий из хранилища объект по его наименованию.
        /// </summary>
        /// <param name="modeControlName">Название режима управления.</param>
        /// <returns>Режим управления или <see langword="null" />.</returns>
        public override ModeControl GetByName(String modeControlName) => GetAll().SingleOrDefault(modeControl => modeControl.Name == modeControlName);

        /// <summary>
        /// Метод получения коллекции допустимых режимов управления для заданного типа двигателя.
        /// </summary>
        /// <param name="motorType">Тип двигателя.</param>
        /// <returns>Перечисление (<see cref="IEnumerable{T}"/>) допустимых режимов управления.</returns>
        public IEnumerable<ModeControl> GetModeControlsForMotorType(MotorType motorType) => GetAll().Where(modeControl => modeControl.MotorType == motorType);
    }
}
