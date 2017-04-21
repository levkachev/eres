using System;
using System.Collections.Generic;
using ORM.Base;

namespace TrainMovement.Stages
{
    /// <summary>
    /// 
    /// </summary>
    public class SpeedLimit : Entity<SpeedLimit>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<LimitStructure> SpeedLimitProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }
    }
}
