using System;
using ORM.Base;
using System.Collections.Generic;


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
        public virtual IList<NM_Line> NM_Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Open_Line> Open_Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Plan_Line> Plan_Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Profil_Line> Profil_Line { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Current_Section> Current_Section { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Limit_Line> Limit_Line { get; set; }


        public Track()
        {
            Station = new List<Station>();
            NM_Line = new List<NM_Line>();
            Open_Line = new List<Open_Line> ();
            Plan_Line = new List<Plan_Line>();
            Profil_Line = new List<Profil_Line>();
            Current_Section = new List<Current_Section>();
            Limit_Line = new List<Limit_Line>();
        }

    }
}
