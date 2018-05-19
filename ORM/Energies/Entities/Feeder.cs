using System;
using System.Collections.Generic;
using ORM.Base;

namespace ORM.Energies.Entities
{
    /// <summary>
    /// Фидер
    /// </summary>
    public class Feeder : NamedEntity<Feeder>
    {
        /// <summary>
        /// Пикетаж
        /// </summary>
        public virtual Double Piketage { get; protected set; }

        /// <summary>
        /// Тип фидера
        /// </summary>
        public virtual String FeederType { get; protected set; }

        /// <summary>
        /// Сопротивление фидера
        /// </summary>
        public virtual Double Resistance { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<Resistance> Resistances { get; protected set; } = new List<Resistance>();

        /// <summary>
        /// Тяговая подстанция
        /// </summary>
        public virtual PowerSupplyStation PowerSupplyStation { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $"R = {Resistance}, Piketage = {Piketage}, Name = {Name}";
    }
}
