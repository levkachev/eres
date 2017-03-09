using System;
using ORM.Base;

namespace ORM.Energy.Entities
{
    /// <summary>
    /// Справочник агрегатов
    /// </summary>
    public class Unit_Name :Entity<Unit_Name>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String Name { get; set; }
    }
}
