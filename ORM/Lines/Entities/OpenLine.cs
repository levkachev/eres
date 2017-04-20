using System;
using ORM.Base;
using System.Collections.Generic;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Открытые линии
    /// </summary>
    public class OpenLine : Entity<OpenLine>
    {
        /// <summary>
        /// KWosn
        /// </summary>
        public virtual Double KWosn { get; set; }

        /// <summary>
        /// Пикетаж начала 
        /// </summary>
        public virtual Double Piketage_Start { get; set; }

        /// <summary>
        /// Пикетаж конец
        /// </summary>
        public virtual Double Piketage_Finish { get; set; }


        /// <summary>
        /// номер пути
        /// </summary>
        public virtual IList<Track> Track { get; set; }

        public OpenLine()
        {
            
            Track = new List<Track>();
            
        }
    }
}