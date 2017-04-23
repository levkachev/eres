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


        public virtual IEnumerable<ASRLine> ASRLines { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<NMLine> NMLines { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<OpenLine> OpenLines { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<PlanLine> PlanLines { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<ProfileLine> ProfileLines { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<CurrentSectionLine> CurrentSectionLines { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<LimitLine> LimitLines { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<Stage> Stages{ get; set; }
        public Track()
        {
            
            NMLines = new SortedSet<NMLine>();
            PlanLines = new SortedSet<PlanLine>();
            ProfileLines = new SortedSet<ProfileLine>();
            CurrentSectionLines = new SortedSet<CurrentSectionLine>();
            LimitLines = new SortedSet<LimitLine>();
            Stages = new SortedSet<Stage>();
            OpenLines = new SortedSet<OpenLine>();
            ASRLines = new SortedSet<ASRLine>();
        }
       
           public override String ToString()
           {
            return $"For {Tracks} ASRLines: {String.Join("; ", ASRLines)}{Environment.NewLine}NMLines: {String.Join("; ", NMLines)}{Environment.NewLine}PlanLines: {String.Join("; ", PlanLines)}{Environment.NewLine}ProfileLines: {String.Join("; ", ProfileLines)}{Environment.NewLine}CurrentSectionLines: {String.Join("; ", CurrentSectionLines)}{Environment.NewLine}LimitLines: {String.Join("; ", LimitLines)}{Environment.NewLine}";
        }
    }
   
}
