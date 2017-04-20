using System;
using ORM.Base;
using System.Collections.Generic;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// ARS Перегон
    /// </summary>
    public class Open_Stage : Entity<Open_Stage>
    {
        /// <summary>
        /// KWosn
        /// </summary>
        public virtual Double KWosn { get; set; }


        /// <summary>
        /// начало
        /// </summary>
        public virtual Double Start { get; set; }

        /// <summary>
        /// конец
        /// </summary>
        public virtual Double Finish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }


    }
}

