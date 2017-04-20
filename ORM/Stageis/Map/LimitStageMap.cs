using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// Ограничения перегона
    /// </summary>
    public class LimitStageMap : ClassMap<LimitStage>
    {
        /// <summary>
        /// 
        /// </summary>
        public LimitStageMap()
        {
            Table("Line.LimitStage");
            Id(x => x.ID);
            Map(x => x.Velocity).Not.Nullable();
            Map(x => x.End_Velocity).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");

        }
    }
}
