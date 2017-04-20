using System;
using ORM.Base;
using System.Collections.Generic;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Немерные Пикеты
    /// </summary>
    public class NM_Line : Entity<NM_Line>
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

       
    }
}
