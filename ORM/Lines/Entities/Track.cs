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

        public virtual IList<Station> Station { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<NMLine> NMLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<OpenLine> OpenLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<PlanLine> PlanLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<ProfileLine> ProfilLine { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public virtual IList<CurrentSection> CurrentSection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<LimitLine> LimitLine { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Stage> Stage { get; set; }
        public Track()
        {
            Station = new List<Station>();
            NMLine = new List<NMLine>();
            OpenLine = new List<OpenLine> ();
            PlanLine = new List<PlanLine>();
            ProfilLine = new List<ProfileLine>();
            CurrentSection = new List<CurrentSection>();
            LimitLine = new List<LimitLine>();
            Stage = new List<Stage>();
        }

    }
}
