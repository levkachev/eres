using System;
using ORM.Base;

namespace ORM.Train.Entities
{
    /// <summary>
    /// режим управления
    /// </summary>
    public class Mode_Control : Entity<Mode_Control>
    {
        /// <summary>
        /// режим управления
        /// </summary>
        public virtual String ModeControl { get; set; }

        /// <summary>
        /// тип двигателя
        /// </summary>
        public virtual Motor_Type MotorType { get; set; }

    }
}
