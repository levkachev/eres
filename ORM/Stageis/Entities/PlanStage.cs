using System;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class PlanStage : Entity<PlanStage>
    {
        /// <summary>
        /// 
        /// </summary>
        public Double Radius { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public Double EndRadius { get; protected set; } 


    }
}
