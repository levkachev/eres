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
        public virtual IList<NMLine> NM_Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<OpenLine> Open_Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<PlanLine> Plan_Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<ProfileLine> Profil_Line { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public virtual IList<CurrentSection> Current_Section { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<LimitLine> Limit_Line { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Stage> Stage { get; set; }
        public Track()
        {
            Station = new List<Station>();
            NM_Line = new List<NMLine>();
            Open_Line = new List<OpenLine> ();
            Plan_Line = new List<PlanLine>();
            Profil_Line = new List<ProfileLine>();
            Current_Section = new List<CurrentSection>();
            Limit_Line = new List<LimitLine>();
            Stage = new List<Stage>();
        }

    }
}
