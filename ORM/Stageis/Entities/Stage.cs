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
        public virtual String St_Department { get; set; }

        /// <summary>
        /// станция назначения
        /// </summary>
        public virtual String St_Arrival { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Track Track { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<ProfileStage> ProfilStage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<PlanStage> PlanStage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual CurrentSectionStage CurrentSectionStage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<LimitStage> LimitStage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<ASRStage> ASRStage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<OpenStage> OpenStage { get; set; }
        public Stage()
        {
            ProfilStage = new SortedSet<ProfileStage>();
            PlanStage = new SortedSet<PlanStage>();
            LimitStage = new SortedSet<LimitStage>();
            ASRStage = new SortedSet<ASRStage>();
            OpenStage = new SortedSet<OpenStage>();
        }

        }
}