using System;
using ORM.Base;

namespace ORM.Train.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class VFI : Entity<VFI>
    {
        /// <summary>
        /// скорость
        /// </summary>
        public virtual Double Velocity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Double ForceMax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Double ForceMin { get; set; }

        /// <summary>
        /// ток max
        /// </summary>
        public virtual Double CurrentMax { get; set; }

        /// <summary>
        /// ток min
        /// </summary>
        public virtual Double CurrentMin { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Mode_Control ModeControl { get; set; }

        /// <summary>
        /// масса поезда
        /// </summary>
        public virtual MassMass Mass { get; set; }
    }
}
