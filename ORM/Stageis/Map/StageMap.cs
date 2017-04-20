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
            Table("Line.Stage");
            Id(x => x.ID);
            Map(x => x.Length).Not.Nullable();
            Map(x => x.St_Department).Length(45).Not.Nullable();
            Map(x => x.St_Arrival).Length(45).Not.Nullable();
            References(x => x.Track).ForeignKey("ID_Track");
            HasMany(x => x.Profil_Stage);
            HasMany(x => x.Plan_Stage);
            HasMany(x => x.Current_Section);
            HasMany(x => x.Limit_Stage);
            HasMany(x => x.ASR_Stage);
            HasMany(x => x.Open_Stage);
        }
    }
}
