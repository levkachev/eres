using System;
using ORM.Base;
using System.Collections.Generic;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Профиль линии
    /// </summary>
    public class Profil_Line : Entity<Profil_Line>
    {
        /// <summary>
        /// Уклон
        /// </summary>
        public virtual Double Slope { get; set; }

        /// <summary>
        /// Пикетаж  
        /// </summary>
        public virtual Double Piketage { get; set; }

      
        /// <summary>
        /// номер пути
        /// </summary>
        public virtual Track Track { get; set; }


    }
}