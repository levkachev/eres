using System;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class ProfileStage:Entity<ProfileStage>
    {
        /// <summary>
        /// 
        /// </summary>
        public Double Slope { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public Double EndSlope { get; protected set; }
    }
}
