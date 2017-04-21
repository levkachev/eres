using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// Перегон
    /// </summary>
    public class StageMap : ClassMap<Stage>
    {
        /// <summary>
        /// 
        /// </summary>
        public StageMap()
        {
            Table("Stage.Stage");
            Id(x => x.ID);
            Map(x => x.Length).Not.Nullable();
            Map(x => x.St_Department).Length(45).Not.Nullable();
            Map(x => x.St_Arrival).Length(45).Not.Nullable();
            References(x => x.Track).ForeignKey("ID_Track");
            HasMany(x => x.ProfilStage);
            HasMany(x => x.PlanStage);
            References(x => x.CurrentSectionStage);
            HasMany(x => x.LimitStage);
            HasMany(x => x.ASRStage);
            HasMany(x => x.OpenStage);
        }
    }
}
