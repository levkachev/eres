using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Немерные Пикеты
    /// </summary>
    public class NMLineMap : ClassMap<NMLine>
    {
        public NMLineMap()
        {
            Table("Line.NMLine");
            Id(x => x.ID);
            Map(x => x.Length).Not.Nullable();
            Map(x => x.Piketage).Column("Piketag").Not.Nullable();
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}