using System;
using ORM.Base;

namespace ORM.Train.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Mode_Control : Entity<Mode_Control>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual String ModeControl { get; set; }

        /// <summary>
        /// тип двигателя
        /// </summary>
        public virtual Motor_Type Motor_Type { get; set; }

    }
}
