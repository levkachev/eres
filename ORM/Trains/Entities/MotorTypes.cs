using System;
using ORM.Base;
using System.Collections.Generic;

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

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<ModeControls> ModeControls { get; set; }
        public MotorTypes()
        {
            ModeControls = new List<ModeControls>();

        }
    }
}
