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
        public virtual IList<Profil_Stage> Profil_Stage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Plan_Stage> Plan_Stage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Current_Section> Current_Section { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Limit_Stage> Limit_Stage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IList<ASR_Stage> ASR_Stage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Open_Stage> Open_Stage { get; set; }
        public Stage()
        {
            Profil_Stage = new List<Profil_Stage>();
            Plan_Stage = new List<Plan_Stage>();
            Current_Section = new List<Current_Section>();
            Limit_Stage = new List<Limit_Stage>();
            ASR_Stage = new List<ASR_Stage>();
            Open_Stage = new List<Open_Stage>();
        }

    }
}