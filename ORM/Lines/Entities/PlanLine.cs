using System;
using ORM.Base;
using System.Collections.Generic;

namespace ORM.Lines.Entities
{
    /// <summary>
    /// План линии
    /// </summary>
    public class PlanLine : Entity<PlanLine>
    {
        /// <summary>
        /// Радиус
        /// </summary>
        public virtual Double Radius { get; set; }

        /// <summary>
        /// Пикетаж начала 
        /// </summary>
        public virtual Double PiketageStart { get; set; }

        /// <summary>
        /// Пикетаж конец
        /// </summary>
        public virtual Double PiketageFinish { get; set; }

        /// <summary>
        /// номер пути
        /// </summary>
        public virtual Track Track { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $" {Radius} {PiketageStart} {PiketageFinish}";
    }
}
