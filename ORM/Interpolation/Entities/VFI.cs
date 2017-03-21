using System;
using ORM.Base;
using ORM.Train.Entities;

namespace ORM.Interpolation.Entities
{
    /// <summary>
    /// характеристики 
    /// </summary>
    public class VFI : Entity<VFI>
    {
        /// <summary>
        /// скорость
        /// </summary>
        public virtual Double Velocity { get; set; }

        /// <summary>
        /// сила тяги (торможения) max
        /// </summary>
        public virtual Double ForceMax { get; set; }

        /// <summary>
        /// сила тяги (торможения) min
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
        /// режим управления
        /// </summary>
        public virtual Mode_Control ModeControl { get; set; }

        /// <summary>
        /// масса поезда
        /// </summary>
        public virtual MassMass Mass { get; set; }

        /// <summary>
        /// наименование поезда
        /// </summary>
        public virtual Train_Name Train { get; set; }
        
    }
}
