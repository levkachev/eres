using System;
using ORM.Base;
using System.Collections.Generic;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// Ограничения перегона
    /// </summary>
    public class LimitStage : Entity<LimitStage>
    {
        /// <summary>
        /// Скорость
        /// </summary>
        public virtual Double Velocity { get; set; }


        /// <summary>
        /// Граница скорости
        /// </summary>
        public virtual Double End_Velocity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }


    }
}
