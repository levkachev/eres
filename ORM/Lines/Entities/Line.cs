using System;
using System.Collections.Generic;
using ORM.Base;
using ORM.Energy.Entities;


namespace ORM.Lines.Entities
{
    /// <summary>
    /// Линия
    /// </summary>
    public class Line : Entity<Line>
    {
        /// <summary>
        /// Наименование линии
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// Цвет линии 
        /// </summary>
        public virtual Color Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<PowerSupplyStation> PowerSupplyStation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<Track> Track { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<Direction> Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Line()
        {
            PowerSupplyStation = new SortedSet<PowerSupplyStation>();
            Track = new SortedSet<Track>();
            Direction = new SortedSet<Direction>();
        }
    }
}
