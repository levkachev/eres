using System;
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
        public virtual IEnumerable<ProfileStage> ProfileStages { get; set; } = new List<ProfileStage>();

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<PlanStage> PlanStages { get; set; } = new List<PlanStage>();

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<CurrentSectionStage> CurrentSectionStages { get; set; } = new List<CurrentSectionStage>();

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<LimitStage> LimitStages { get; set; } = new List<LimitStage>();


        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<ASRStage> ASRStages { get; set; } = new List<ASRStage>();


        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<OpenStage> OpenStages { get; set; } = new List<OpenStage>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $"For {Length} ";
    }
}