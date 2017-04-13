using System;
using System.Collections.Generic;
using ORM.Base;


namespace ORM.Energy.Entities
{
    /// <summary>
    /// Тяговые подстанции
    /// </summary>
    public class PowerSupplyStation : Entity<PowerSupplyStation>
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
        /// Линия
        /// </summary>
        public virtual Lines.Entities.Line Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Unit> Units { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Feeder> Feeders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PowerSupplyStation()
        {
            Units = new List<Unit>();
            Feeders = new List<Feeder>();
        }

        public override String ToString()
        {
            return $"For {Name} [{Piketage}]{Environment.NewLine}Units: {String.Join("; ", Units)}{Environment.NewLine}Feeders: {String.Join("; ", Feeders)}{Environment.NewLine}";
        }
    }
}
