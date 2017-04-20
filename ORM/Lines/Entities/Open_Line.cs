using System;
using ORM.Base;
using System.Collections.Generic;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Открытые линии
    /// </summary>
    public class Open_Line : Entity<Open_Line>
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

        public Open_Line()
        {
            
            Track = new List<Track>();
            
        }
    }
}