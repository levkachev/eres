using System;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// Токораздел перегона
    /// </summary>
    public class CurrentSectionStage : Entity<CurrentSectionStage>
    {
        /// <summary>
        /// Начало
        /// </summary>
        public virtual Double Start { get; set; }


        /// <summary>
        /// Конец
        /// </summary>
        public virtual Double Finish { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }

        public override String ToString()
        {
            return $" {Start} {Finish} ";

        }
    }
}