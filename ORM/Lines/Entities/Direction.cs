﻿using System;
using ORM.Base;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Направление
    /// </summary>
    public class Direction : Entity<Direction>
    {
        /// <summary>
        /// напрвление (1 или 2)
        /// </summary>
        public virtual Int32 Directions { get; set; }

        /// <summary>
        /// пикетаж начало
        /// </summary>
        public virtual Double PiketageStart { get; set; }

        /// <summary>
        /// пикетаж конец
        /// </summary>
        public virtual Double PiketageFinish { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Line Line { get; set; }

        public override String ToString()
        {
            return $" {Directions} {PiketageStart} {PiketageFinish}";
        }
    }
}
