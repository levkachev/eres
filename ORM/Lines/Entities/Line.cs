using System;
using System.Collections.Generic;
using ORM.Base;
using ORM.Energies.Entities;

namespace ORM.Lines.Entities
{
    /// <summary>
    /// Линия
    /// </summary>
    public class Line : NamedEntity<Line>
    {
        /// <summary>
        /// Цвет линии 
        /// </summary>
        public virtual Color Color { get; set; }

        /// <summary>
        /// Тяговые подстанции
        /// </summary>
        public virtual IEnumerable<PowerSupplyStation> PowerSupplyStations { get; set; } = new List<PowerSupplyStation>();

        /// <summary>
        /// Пути линии
        /// </summary>
        public virtual IEnumerable<Track> Tracks { get; set; } = new List<Track>();

        /// <summary>
        /// Направления
        /// </summary>
        public virtual IEnumerable<Direction> Directions { get; set; } = new List<Direction>();

        /// <summary>
        /// Станции
        /// </summary>
        public virtual IEnumerable<Station> Stations { get; set; } = new List<Station>();
    }
}
