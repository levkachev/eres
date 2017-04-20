using System;
using ORM.Base;
using System.Collections.Generic;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Токораздел линии
    /// </summary>
    public class Current_Section : Entity<Current_Section>
    {
        /// <summary>
        /// Пикетаж начала 
        /// </summary>
        public virtual Double Piketage_Start { get; set; }

        /// <summary>
        /// Пикетаж конец
        /// </summary>
        public virtual Double Piketage_Finish { get; set; }


        /// <summary>
        /// номер пути
        /// </summary>
        public virtual Track Track { get; set; }


    }
}