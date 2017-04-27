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
            References(x => x.Arrival).ForeignKey("ID_Arrival");
            References(x => x.Departure).ForeignKey("ID_Departure");
            References(x => x.Track).ForeignKey("ID_Track");
            HasMany(x => x.ProfileStages);
            HasMany(x => x.PlanStages);
            HasMany(x => x.CurrentSectionStages);
            HasMany(x => x.LimitStages);
            HasMany(x => x.ASRStages);
            HasMany(x => x.OpenStages);
        }
    }
}
