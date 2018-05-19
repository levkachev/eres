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
        public virtual Double Slope { get; protected set; }

        /// <summary>
        /// Граница уклона
        /// </summary>
        public virtual Double EndSlope { get; protected set; }
     
        /// <summary>
        /// Перегон
        /// </summary>
        public virtual Stage Stage { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $" {Slope} {EndSlope} ";
    }
}
