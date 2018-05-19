using System;
using ORM.Base;
using System.Collections.Generic;
using ORM.Trains.Interpolation.Entities;

namespace ORM.Trains.Entities
{
    /// <summary>
    /// Режим управления
    /// </summary>
    public class ModeControl : NamedEntity<ModeControl>
    {
        /// <inheritdoc />
        /// <summary>
        /// Название режима управления --> { "Ход" | "Выбег" | "Торможение" }
        /// </summary>
        public override String Name { get; protected set; }

        /// <summary>
        /// Тип двигателя (AC или DC).
        /// </summary>
        public virtual MotorType MotorType { get; protected set; }

        /// <summary>
        /// Тяговые и скоростные характеристики для текущего режима управления.
        /// </summary>
        public virtual IEnumerable<ElectricTractionCharacteristics> Characteristics { get; protected set; } = new List<ElectricTractionCharacteristics>();
    }
}
