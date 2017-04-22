using System;
using ORM.Base;

namespace ORM.Trains.Entities
{
    /// <summary>
    /// поезд
    /// </summary>
    public class TrainName : Entity<TrainName>
    {
        /// <summary>
        /// наименование поезда 
        /// </summary>
        public virtual String Name { get; set; }
        /// <summary>
        /// тип двигателя
        /// </summary>
        public virtual MotorTypes MotorType { get; set; }
    }
    
}
