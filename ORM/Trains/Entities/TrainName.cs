using System;
using ORM.Base;
using System.Collections.Generic;
using ORM.Trains.Interpolation.Entities;
    
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

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<AdditionalParameter> АdditionalParameters { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<VFI> VFIs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TrainName()
        {
            АdditionalParameters = new List<AdditionalParameter>();
            VFIs= new List<VFI>();


        }
    }
    
}
