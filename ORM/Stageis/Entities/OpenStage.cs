using System;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenStage:Entity<OpenStage>
    {
        /// <summary>
        /// 
        /// </summary>
        public Double KWosn { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public Double Start { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public Double Finish { get; protected set; }
    }
}
