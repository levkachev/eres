﻿using System;
using ORM.Base;
using System.Collections.Generic;
using ORM.Lines.Entities;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// Перегон
    /// </summary>
    public class Stage : Entity<Stage>
    {
        /// <summary>
        /// длина
        /// </summary>
        public virtual Double Length { get; set; }

        /// <summary>
        /// станция отправления
        /// </summary>
        public virtual Station Departure { get; set; }

        /// <summary>
        /// станция назначения
        /// </summary>
        public virtual Station Arrival { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Track Track { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<ProfileStage> ProfileStages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<PlanStage> PlanStages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<CurrentSectionStage> CurrentSectionStages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<LimitStage> LimitStages { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<ASRStage> ASRStages { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<OpenStage> OpenStages { get; set; }

        public Stage()
        {
            ProfileStages = new List<ProfileStage>();
            PlanStages = new List<PlanStage>();
            LimitStages = new List<LimitStage>();
            ASRStages = new List<ASRStage>();
            OpenStages = new List<OpenStage>();
            CurrentSectionStages = new List<CurrentSectionStage>();
        }

        public override String ToString()
        {
            return $"For {Length} ";
        }

    }
}