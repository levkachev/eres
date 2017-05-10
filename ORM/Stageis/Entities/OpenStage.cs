using System;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// ARS Перегон
    /// </summary>
    public class OpenStage : Entity<OpenStage>
    {
        /// <summary>
        /// KWosn
        /// </summary>
        public virtual Double KWosn { get; set; }


        /// <summary>
        /// начало
        /// </summary>
        public virtual Double Start { get; set; }

        /// <summary>
        /// конец
        /// </summary>
        public virtual Double Finish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }


        public override String ToString()
        {
            return $" {KWosn} {Start} {Finish}";

        }
    }
}

