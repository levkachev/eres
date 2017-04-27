using System;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// План перегона
    /// </summary>
    public class PlanStage : Entity<PlanStage>
    {
        /// <summary>
        /// Радиус
        /// </summary>
        public virtual Double Radius { get; set; }


        /// <summary>
        /// Граница радиуса
        /// </summary>
        public virtual Double EndRadius { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }

        public override String ToString()
        {
            return $" {Radius} {EndRadius} ";

        }
    }
}

