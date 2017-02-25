using System;
using ORM.Base;

namespace ORM.Energy.Entities
{
    /// <summary>
    /// Справочник трансформаторов
    /// </summary>
    public class PowerConvert : Entity<PowerConvert>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// Напряжение вентильной обмотки, В
        /// </summary>
        public virtual Double U2 { get; set; }

        /// <summary>
        /// Полная мощность, кВА
        /// </summary>
        public virtual Double S { get; set; }

        /// <summary>
        /// Коэффициент трансформации
        /// </summary>
        public virtual Double Kt { get; set; }

        /// <summary>
        /// Мощность кз
        /// </summary>
        public virtual Double Pkz { get; set; }
    }
}
