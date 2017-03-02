using System;
using ORM.Base;


namespace ORM.Line.Entities
{
    /// <summary>
    /// Линия
    /// </summary>
    public class LineLine : Entity<LineLine>
    {
        /// <summary>
        /// Наименование линии
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// Цвет линии 
        /// </summary>
        public virtual Color Color { get; set; }
    }
}
