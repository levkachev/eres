using System;
using ORM.Base;
using ORM.Trains.Interpolation.Entities;
using System.Collections.Generic;


namespace ORM.Trains.Entities
{
    /// <summary>
    /// масса поезда
    /// </summary>
    public class MassMass : Entity<MassMass>
    {
        /// <summary>
        /// масс поезда
        /// </summary>
        public virtual Double Mass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<VFI> VFIs { get; set; }
        public MassMass()
        {
          
            VFIs = new List<VFI>();


        }
    }
}
