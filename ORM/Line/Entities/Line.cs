using System;
using ORM.Base;


namespace ORM.Line.Entities
{
    /// <summary>
    /// Линия
    /// </summary>
    public class Line : Entity<Line>
    {
        /// <summary>
        /// Наименование линии
        /// </summary>
        public virtual Int32 Name { get; set; }

        /// <summary>
        /// Цвет линии 
        /// </summary>
        public virtual Color Color { get; set; }
    }
}
