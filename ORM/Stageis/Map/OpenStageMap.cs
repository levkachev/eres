using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// Открытые перегоны
    /// </summary>
    public class OpenStageMap : ClassMap<OpenStage>
    {
        /// <summary>
        /// 
        /// </summary>
        public OpenStageMap()
        {
            Table("Line.OpenStage");
            Id(x => x.ID);
            Map(x => x.KWosn).Not.Nullable();
            Map(x => x.Start).Not.Nullable();
            Map(x => x.Finish).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");

        }
    }
}
