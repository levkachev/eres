using System;
using ORM.Base;
using System.Collections.Generic;

namespace ORM.Trains.Entities
{
    /// <summary>
    /// Тип двигателя.
    /// </summary>
    public class MotorType : NamedEntity<MotorType>
    {
        /// <inheritdoc />
        /// <summary>
        /// Наименование типа двигателя (АС, DC).
        /// </summary>
        public override String Name { get; protected set; }

        /// <summary>
        /// Возможные режимы управления для данного типа двигателя.
        /// </summary>
        public virtual IEnumerable<ModeControl> ModeControls { get; protected set; } = new List<ModeControl>();
    }
}
