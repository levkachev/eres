using System;
using ORM.Base;
using System.Collections.Generic;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// План линии
    /// </summary>
    public class Plan_Line : Entity<Plan_Line>
    {
        /// <summary>
        /// Радииус
        /// </summary>
        public virtual Double Radius { get; set; }

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
