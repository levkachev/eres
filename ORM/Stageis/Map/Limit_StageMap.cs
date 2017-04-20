using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// Ограничения перегона
    /// </summary>
    public class Limit_StageMap : ClassMap<Limit_Stage>
    {
        /// <summary>
        /// 
        /// </summary>
        public Limit_StageMap()
        {
            Table("Line.Limit_Stage");
            Id(x => x.ID);
            Map(x => x.Velocity).Not.Nullable();
            Map(x => x.End_Velocity).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");

        }
    }
}
