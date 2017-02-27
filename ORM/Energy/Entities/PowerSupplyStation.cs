using System;
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
        public virtual Double Piketag { get; set; }

        /// <summary>
        /// Линия
        /// </summary>
        public virtual Line.Entities.Line Line { get; set; }
       
       
    }
}
