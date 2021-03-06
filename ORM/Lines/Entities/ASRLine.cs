﻿using System;
using ORM.Base;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Автоматическое регулирование скорости. Данные по Линии
    /// </summary>
    public class ASRLine : Entity<ASRLine>
    {
        /// <summary>
        /// Наименование линии
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// Ограничения 
        /// </summary>
        public virtual Double Limit { get; set; }

        /// <summary>
        /// пикетаж 
        /// </summary>
        public virtual Double Piketage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Track Track { get; set; }

        public override String ToString()
        {
            return $" {Name} {Limit} {Piketage}";
        }

    }
}

