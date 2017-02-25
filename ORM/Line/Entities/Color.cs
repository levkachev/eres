using System;
using ORM.Base;

namespace ORM.Line.Entities
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
    }
}
