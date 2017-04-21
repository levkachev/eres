using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// План линии
    /// </summary>
    public class PlanLineMap : ClassMap<PlanLine>
    {
        public PlanLineMap()
        {
            Table("Line.PlanLine");
            Id(x => x.ID);
            Map(x => x.Radius).Not.Nullable();
            Map(x => x.PiketageStart).Column("PiketagStart");
            Map(x => x.PiketageFinish).Column("PiketagFinish");
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}