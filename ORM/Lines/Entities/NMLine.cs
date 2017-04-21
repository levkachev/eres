using System;
using ORM.Base;
using System.Collections.Generic;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Немерные Пикеты
    /// </summary>
    public class NMLine : Entity<NMLine>
    {
        /// <summary>
        /// длина
        /// </summary>
        public virtual Double Length { get; set; }

        /// <summary>
        /// пикетаж 
        /// </summary>
        public virtual Double Piketage { get; set; }

       
        /// <summary>
        /// номер пути
        /// </summary>
        public virtual Track Track { get; set; }

        public override String ToString()
        {
            return $" {Length} {Piketage}";
        }
    }
}
