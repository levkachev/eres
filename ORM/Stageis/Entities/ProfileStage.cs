using System;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// Профиль перегона
    /// </summary>
    public class ProfileStage : Entity<ProfileStage>
    {
        /// <summary>
        /// Уклон
        /// </summary>
        public virtual Double Slope { get; set; }


        /// <summary>
        /// Граница уклона
        /// </summary>
        public virtual Double EndSlope { get; set; }

        
        /// <summary>
        /// перегон
        /// </summary>
        public virtual Stage Stage { get; set; }


        public override String ToString()
        {
            return $" {Slope} {EndSlope} ";

        }





    }
}
