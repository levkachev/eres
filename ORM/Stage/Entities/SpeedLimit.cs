using System;
using ORM.Base;

namespace ORM.Stage.Entities
{
    public class SpeedLimit : Entity<SpeedLimit>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual String Name { get; set; }
    }
}
