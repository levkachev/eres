using System;
using ORM.Base;
using System.Collections.Generic;



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

        public override String ToString()
        {
            return $" {PiketageStart} {PiketageFinish}";
        }
    }
}