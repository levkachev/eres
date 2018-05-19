using System;
using ORM.Base;

namespace ORM.Lines.Entities
{
    /// <summary>
    /// Ограничения линий
    /// </summary>
    public class LimitLine : Entity<LimitLine>
    {
        /// <summary>
        /// Ограничения
        /// </summary>
        public virtual Double Limit { get; set; }

        /// <summary>
        /// Пикетаж
        /// </summary>
        public virtual Double Piketage { get; set; }

        /// <summary>
        /// номер пути
        /// </summary>
        public virtual Track Track { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $" {Limit} {Piketage}";
    }
}