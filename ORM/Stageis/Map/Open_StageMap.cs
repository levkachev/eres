using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// Открытые перегоны
    /// </summary>
    public class Open_StageMap : ClassMap<Open_Stage>
    {
        /// <summary>
        /// 
        /// </summary>
        public Open_StageMap()
        {
            Table("Line.Open_Stage");
            Id(x => x.ID);
            Map(x => x.KWosn).Not.Nullable();
            Map(x => x.Start).Not.Nullable();
            Map(x => x.Finish).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");

        }
    }
}
