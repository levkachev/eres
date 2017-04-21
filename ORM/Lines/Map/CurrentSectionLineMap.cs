using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Токораздел линии
    /// </summary>
    public class CurrentSectionLineMap : ClassMap<CurrentSectionLine>
    {
        public CurrentSectionLineMap()
        {
            Table("Line.CurrentSectionLine");
            Id(x => x.ID);
            Map(x => x.Piketage_Start).Column("Piketag_Start");
            Map(x => x.Piketage_Finish).Column("Piketag_Finish");
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}