using System;
using ORM.Base;
using System.Collections.Generic;
using ORM.Trains.Interpolation.Entities;

namespace ORM.Trains.Entities
{
    /// <summary>
    /// режим управления
    /// </summary>
    public class ModeControls : Entity<ModeControls>
    {
        /// <summary>
        /// режим управления
        /// </summary>
        public virtual String ModeControl { get; set; }

        /// <summary>
        /// тип двигателя
        /// </summary>
        public virtual MotorTypes MotorType { get; set; }

        public virtual IEnumerable<VFI> VFIs { get; set; }
        public ModeControls()
        {

            VFIs = new SortedSet<VFI>();


        }

    }
}
