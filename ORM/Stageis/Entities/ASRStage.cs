﻿using System;
using ORM.Base;
using System.Collections.Generic;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// ARS Перегон
    /// </summary>
    public class ASRStage : Entity<ASRStage>
    {
        /// <summary>
        /// Скорость
        /// </summary>
        public virtual Double Velocity { get; set; }


        /// <summary>
        /// Граница скорости
        /// </summary>
        public virtual Double End_Velocity { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }


    }
}
