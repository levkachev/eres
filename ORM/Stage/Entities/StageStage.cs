using System;
using ORM.Base;
using System.Collections.Generic;

namespace ORM.Stage.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class StageStage : Entity<StageStage>
    {
        /// <summary>
        /// 
        /// </summary>
        public  String Name;
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SpeedLimit> SpeedLimit;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="speedLmit"></param>
        public StageStage()
        {
            SpeedLimit = new SortedSet<SpeedLimit>();
        }
    }
}
