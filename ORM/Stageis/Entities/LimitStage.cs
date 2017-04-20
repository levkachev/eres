using System;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class LimitStage:Entity<LimitStage>
    {
        /// <summary>
        /// 
        /// </summary>
        public Double Velocity { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public Double EndVelocity { get; protected set; }
    }
}
