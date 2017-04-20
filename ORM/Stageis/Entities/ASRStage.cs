using System;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class ASRStage: Entity<ASRStage>
    {
        // public Stage Stage {get; protected set;}
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
