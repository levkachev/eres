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
            Map(x => x.PiketageStart).Column("PiketagStart");
            Map(x => x.PiketageFinish).Column("PiketagFinish");
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}