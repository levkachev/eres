using System;
using ORM.Base;

namespace ORM.Stage.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Stage : Entity<Stage>
    {
        /// <summary>
        /// 
        /// </summary>
        public  String Name;
        /// <summary>
        /// 
        /// </summary>
        public SpeedLimit SpeedLmit;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="speedLmit"></param>
        public Stage(String name, SpeedLimit speedLmit)
        {
        }
    }
}
