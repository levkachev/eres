using System;
using ORM.Base;


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
        
    }
}
