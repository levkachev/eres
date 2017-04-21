using System;
using ORM.Base;

namespace ORM.Lines.Entities
{
    /// <summary>
    /// Цвет линии
    /// </summary>
    public class Color : Entity<Color>
    {
        /// <summary>
        /// Наименование цвета линии
        /// </summary>
        public virtual String Colors { get; set; }

        /// <summary>
        /// RGB цвета линии
        /// </summary>
        public virtual String RGBvalue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Line Line { get; set; }

    }
}
