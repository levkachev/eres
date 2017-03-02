using System;
using ORM.Base;

namespace ORM.Train.Entities
{
    /// <summary>
    /// поезд
    /// </summary>
    public class Train_Name : Entity<Train_Name>
    {
        /// <summary>
        /// наименование поезда 
        /// </summary>
        public virtual String Name { get; set; }
        /// <summary>
        /// тип двигателя
        /// </summary>
        public virtual Motor_Type MotorType { get; set; }
    }
    
}
