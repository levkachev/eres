using System;
using System.Collections.Generic;
using ORM.Base;

namespace ORM.Energies.Entities
{
    /// <summary>
    /// Тяговые подстанции
    /// </summary>
    public class PowerSupplyStation : NamedEntity<PowerSupplyStation>
    {
        /// <summary>
        /// Пикетаж
        /// </summary>
        public virtual Double Piketage { get; protected set; }

        /// <summary>
        /// Линия
        /// </summary>
        public virtual Lines.Entities.Line Line { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<Unit> Units { get; protected set; } = new List<Unit>();

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<Feeder> Feeders { get; protected set; } = new List<Feeder>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $"For {Name} [{Piketage}]{Environment.NewLine}{MakeReport(Units, nameof(Units))}{MakeReport(Feeders, nameof(Feeders))}";
    }
}
