using System;
using ORM.Base;

namespace ORM.Trains.Entities
{
    /// <summary>
    /// тип двигателя
    /// </summary>
    public class MotorTypes : Entity<MotorTypes>
    {
        /// <summary>
        /// тип двигателя (АС, DC)
        /// </summary>
        public virtual String MotorType { get; set; }

    }
}
