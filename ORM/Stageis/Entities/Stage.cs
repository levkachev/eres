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
        public virtual IList<ProfileStage> Profil_Stage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<PlanStage> Plan_Stage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<CurrentSection> Current_Section { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<LimitStage> Limit_Stage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IList<ASRStage> ASR_Stage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IList<OpenStage> Open_Stage { get; set; }
        public Stage()
        {
            Profil_Stage = new List<ProfileStage>();
            Plan_Stage = new List<PlanStage>();
            Current_Section = new List<CurrentSection>();
            Limit_Stage = new List<LimitStage>();
            ASR_Stage = new List<ASRStage>();
            Open_Stage = new List<OpenStage>();
        }

    }
}