using System;
using ORM.Base;
using System.Collections.Generic;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// Токораздел перегона
    /// </summary>
    public class CurrentSection : Entity<CurrentSection>
    {
        /// <summary>
        /// Начало
        /// </summary>
        public virtual Double Start { get; set; }


        /// <summary>
        /// Конец
        /// </summary>
        public virtual Double Finish { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }


    }
}