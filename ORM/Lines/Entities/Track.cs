using System;
using ORM.Base;
using System.Collections.Generic;
using ORM.Stageis.Entities;

namespace ORM.Lines.Entities
{
    /// <summary>
    /// Путь
    /// </summary>
    public class Track : Entity<Track>
    {
        /// <summary>
        /// номер пути
        /// </summary>
        public virtual Int32 Tracks { get; set; }

             /// <summary>
        /// 
        /// </summary>
        public virtual Line Line { get; set; }


        public virtual ASRLine ASRLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<Station> Station { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<NMLine> NMLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual OpenLine OpenLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<PlanLine> PlanLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<ProfileLine> ProfileLine { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<CurrentSectionLine> CurrentSectionLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<LimitLine> LimitLine { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<Stage> Stage { get; set; }
        public Track()
        {
            Station = new SortedSet<Station>();
            NMLine = new SortedSet<NMLine>();
            PlanLine = new SortedSet<PlanLine>();
            ProfileLine = new SortedSet<ProfileLine>();
            CurrentSectionLine = new SortedSet<CurrentSectionLine>();
            LimitLine = new SortedSet<LimitLine>();
            Stage = new SortedSet<Stage>();
        }

    }
}
