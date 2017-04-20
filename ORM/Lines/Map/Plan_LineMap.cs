using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// План линии
    /// </summary>
    public class Plan_LineMap : ClassMap<Plan_Line>
    {
        public Plan_LineMap()
        {
            Table("Line.Plan_Line");
            Id(x => x.ID);
            Map(x => x.Radius).Not.Nullable();
            Map(x => x.Piketage_Start).Column("Piketag_Start");
            Map(x => x.Piketage_Finish).Column("Piketag_Finish");
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}