using System;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// Ограничения перегона
    /// </summary>
    public class LimitStage : Entity<LimitStage>
    {
        /// <summary>
        /// Скорость
        /// </summary>
        public virtual Double Velocity { get; set; }

        /// <summary>
        /// Граница скорости
        /// </summary>
        public virtual Double EndVelocity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $" {Velocity} {EndVelocity}";
    }
}
