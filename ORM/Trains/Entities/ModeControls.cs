using System;
using ORM.Base;

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

    }
}
