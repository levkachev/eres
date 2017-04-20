using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// Токораздел перегона
    /// </summary>
    public class Current_SectionMap : ClassMap<Current_Section>
    {
        /// <summary>
        /// 
        /// </summary>
        public Current_SectionMap()
        {
            Table("Line.Current_Section");
            Id(x => x.ID);
            Map(x => x.Start).Not.Nullable();
            Map(x => x.Finish).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");

        }
    }
}
