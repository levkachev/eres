using System;
using ORM.Base;
using ORM.Line.Entities;


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
        public virtual LineLine Line { get; set; }
       
       
    }
}
