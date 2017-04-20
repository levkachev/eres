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
            Map(x => x.Piketage_Start).Column("Piketag_Start");
            Map(x => x.Piketage_Finish).Column("Piketag_Finish");
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}