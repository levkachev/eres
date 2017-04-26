using System;
using System.Collections.Generic;
using ORM.Base;

namespace ORM.Energy.Entities
{
    /// <summary>
    /// Фидер
    /// </summary>
    public class Feeder : Entity<Feeder>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// Пикетаж
        /// </summary>
        public virtual Double Piketage { get; set; }

        /// <summary>
        /// Тип фидера
        /// </summary>
        public virtual String FeederType { get; set; }

        /// <summary>
        /// Сопротивление фидера
        /// </summary>
        public virtual Double Resistance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<Resistance> Resistances { get; set; }

        /// <summary>
        /// Тяговая подстанция
        /// </summary>
        public virtual PowerSupplyStation PowerSupplyStation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return $"R = {Resistance}, Piketage = {Piketage}, Name = {Name}";
        }

        public Feeder()
        {
            Resistances = new List<Resistance>();
        }
    }
}
