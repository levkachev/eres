using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Токораздел линии
    /// </summary>
    public class Current_SectionMap : ClassMap<Current_Section>
    {
        public Current_SectionMap()
        {
            Table("Line.Current_Section");
            Id(x => x.ID);
            Map(x => x.Piketage_Start).Column("Piketag_Start");
            Map(x => x.Piketage_Finish).Column("Piketag_Finish");
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}