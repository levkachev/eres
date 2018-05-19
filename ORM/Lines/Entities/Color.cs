using System;
using ORM.Base;

namespace ORM.Lines.Entities
{
    /// <summary>
    /// Цвет линии
    /// </summary>
    public class Color : NamedEntity<Color>
    {
        /// <summary>
        /// RGB цвета линии
        /// </summary>
        public virtual String RGB { get; protected set; }

        /// <summary>
        /// Линия
        /// </summary>
        public virtual Line Line { get; protected set; }
    }
}
