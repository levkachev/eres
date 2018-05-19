using System;
using ORM.Base;

namespace ORM.Lines.Entities
{
    /// <summary>
    /// Токораздел линии
    /// </summary>
    public class CurrentSectionLine : Entity<CurrentSectionLine>
    {
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
        public override String ToString() => $" {PiketageStart} {PiketageFinish}";
    }
}