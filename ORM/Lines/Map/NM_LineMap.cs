using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Немерные Пикеты
    /// </summary>
    public class NM_LineMap : ClassMap<NM_Line>
    {
        public NM_LineMap()
        {
            Table("Line.NM_Line");
            Id(x => x.ID);
            Map(x => x.Length).Not.Nullable();
            Map(x => x.Piketage).Column("Piketag").Not.Nullable();
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}