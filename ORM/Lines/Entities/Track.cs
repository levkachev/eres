using ORM.Base;
using ORM.Stageis.Entities;
using System;
using System.Collections.Generic;

namespace ORM.Lines.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Путь
    /// </summary>
    public class Track : Entity<Track>
    {
        /// <summary>
        /// Номер пути
        /// </summary>
        public virtual Int32 Number { get; protected set; }

        /// <summary>
        /// Линия
        /// </summary>
        public virtual Line Line { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<ASRLine> ASRLines { get; protected set; } = new List<ASRLine>();

        /// <summary>
        /// Немереные пикеты
        /// </summary>
        public virtual IEnumerable<NMLine> NMLines { get; protected set; } = new List<NMLine>();

        /// <summary>
        /// Открытые участки линии
        /// </summary>
        public virtual IEnumerable<OpenLine> OpenLines { get; protected set; } = new List<OpenLine>();

        /// <summary>
        /// План
        /// </summary>
        public virtual IEnumerable<PlanLine> PlanLines { get; protected set; } = new List<PlanLine>();

        /// <summary>
        /// Профиль
        /// </summary>
        public virtual IEnumerable<ProfileLine> ProfileLines { get; protected set; } = new List<ProfileLine>();

        /// <summary>
        /// Неперекрываемые токоразделы
        /// </summary>
        public virtual IEnumerable<CurrentSectionLine> CurrentSectionLines { get; protected set; } = new List<CurrentSectionLine>();

        /// <summary>
        /// Ограничения скорости на линии
        /// </summary>
        public virtual IEnumerable<LimitLine> LimitLines { get; protected set; } = new List<LimitLine>();

        /// <summary>
        /// Перегоны
        /// </summary>
        public virtual IEnumerable<Stage> Stages{ get; protected set; } = new List<Stage>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => 
            $"For {Number} {MakeReport(ASRLines, nameof(ASRLines))}{MakeReport(NMLines, nameof(NMLines))}{MakeReport(PlanLines, nameof(PlanLines))}{MakeReport(ProfileLines, nameof(ProfileLines))}{MakeReport(CurrentSectionLines, nameof(CurrentSectionLines))}{MakeReport(LimitLines, nameof(LimitLines))}";
    }
}
