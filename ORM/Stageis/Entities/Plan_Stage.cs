using System;
using ORM.Base;
using System.Collections.Generic;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// План перегона
    /// </summary>
    public class Plan_Stage : Entity<Plan_Stage>
    {
        /// <summary>
        /// Радиус
        /// </summary>
        public virtual Double Radius { get; set; }


        /// <summary>
        /// Граница радиуса
        /// </summary>
        public virtual Double End_Radius { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }








    }
}

