using System;
using ORM.Base;
using System.Collections.Generic;
using ORM.Stageis.Entities;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Станция
    /// </summary>
    public class Station : Entity<Station>
    {
        /// <summary>
        /// наименование
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// пикетаж 
        /// </summary>
        public virtual Double Piketage { get; set; }

        /// <summary>
        /// сокращенное наименование
        /// </summary>
        public virtual String Short_Name { get; set; }

        /// <summary>
        /// номер пути
        /// </summary>
        public virtual IEnumerable<Track> Track { get; set; }

        public virtual Stage Department { get; set; }
        public virtual Stage Arrival { get; set; }
        public Station()
        {
            Track = new SortedSet<Track>();
            
        }
        public override String ToString()
        {
            return $" {Name} {Piketage} {Department} {Arrival}";
        }
    }
}