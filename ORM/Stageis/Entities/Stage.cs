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
        public virtual Station Department { get; set; }

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
        public virtual IEnumerable<ProfileStage> ProfilStages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<PlanStage> PlanStages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual CurrentSectionStage CurrentSectionStage { get; set; }

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
            ProfilStages = new SortedSet<ProfileStage>();
            PlanStages = new SortedSet<PlanStage>();
            LimitStages = new SortedSet<LimitStage>();
            ASRStages = new SortedSet<ASRStage>();
            OpenStages = new SortedSet<OpenStage>();
        }

        public override String ToString()
        {
            return $"For {Length} ";
        }

    }
}