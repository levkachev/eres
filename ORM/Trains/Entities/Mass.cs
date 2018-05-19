using ORM.Base;
using ORM.Trains.Interpolation.Entities;
using System;
using System.Collections.Generic;

namespace ORM.Trains.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Масса поезда
    /// </summary>
    public class Mass : Entity<Mass>
    {
        /// <summary>
        /// Значение массы поезда (ключевое поле).
        /// </summary>
        public virtual Double Value { get; protected set; }

        /// <summary>
        /// Тяговые и скоростные характеристики для текущей массы (<see cref="Value"/>).
        /// </summary>
        public virtual IEnumerable<ElectricTractionCharacteristics> Characteristics { get; set; } = new List<ElectricTractionCharacteristics>();
    }
}
