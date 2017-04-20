using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// Токораздел перегона
    /// </summary>
    public class CurrentSectionMap : ClassMap<CurrentSection>
    {
        /// <summary>
        /// 
        /// </summary>
        public CurrentSectionMap()
        {
            Table("Line.CurrentSection");
            Id(x => x.ID);
            Map(x => x.Start).Not.Nullable();
            Map(x => x.Finish).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");

        }
    }
}
