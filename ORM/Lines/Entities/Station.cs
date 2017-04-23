using System;
using ORM.Base;
using System.Collections.Generic;
using ORM.Stageis.Entities;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Станция
    /// </summary>
    public class Station : Entity<Station>
    {
        /// <summary>
        /// наименование
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// пикетаж 
        /// </summary>
        public virtual Double Piketage { get; set; }

        /// <summary>
        /// сокращенное наименование
        /// </summary>
        public virtual String ShortName { get; set; }

        /// <summary>
        /// линия
        /// </summary>
        public virtual Line Line{ get; set; }

        //  public virtual Stage Departure { get; set; }
        //   public virtual Stage Arrival { get; set; }

        public override String ToString()
        {
            return $" {Name} {Piketage}";
//{Departure} {Arrival}";
        }
    }
}