using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Открытые линии
    /// </summary>
    public class Open_LineMap : ClassMap<Open_Line>
    {
        public Open_LineMap()
        {
            Table("Line.Open_Line");
            Id(x => x.ID);
            Map(x => x.KWosn).Not.Nullable();
            Map(x => x.Piketage_Start).Column("Piketag_Start");
            Map(x => x.Piketage_Finish).Column("Piketag_Finish");
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}
