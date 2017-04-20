using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// План перегона
    /// </summary>
    public class Plan_StageMap : ClassMap<Plan_Stage>
    {
        /// <summary>
        /// 
        /// </summary>
        public Plan_StageMap()
        {
            Table("Line.Plan_Stage");
            Id(x => x.ID);
            Map(x => x.Radius).Not.Nullable();
            Map(x => x.End_Radius).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");

        }
    }
}
