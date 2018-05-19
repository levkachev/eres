using System;
using ORM.Base;
using System.Collections.Generic;

namespace ORM.Lines.Entities
{
    /// <summary>
    /// Открытые линии
    /// </summary>
    public class OpenLine : Entity<OpenLine>
    {
        /// <summary>
        /// KWosn
        /// </summary>
        public virtual Double KWosn { get; set; }

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
        public virtual IEnumerable<Track> Tracks { get; set; } = new List<Track>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $" {KWosn} {PiketageStart} {PiketageFinish}";
    }
}