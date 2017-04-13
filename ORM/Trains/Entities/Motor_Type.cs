using System;
using ORM.Base;

namespace ORM.Train.Entities
{
    /// <summary>
    /// тип двигателя
    /// </summary>
    public class Motor_Type : Entity<Motor_Type>
    {
        /// <summary>
        /// тип двигателя (АС, DC)
        /// </summary>
        public virtual String MotorType { get; set; }

    }
}
