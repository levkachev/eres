using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Ограничения линий
    /// </summary>
    public class Limit_LineMap : ClassMap<Limit_Line>
    {
        public Limit_LineMap()
        {
            Table("Line.Limit_Line");
            Id(x => x.ID);
            Map(x => x.Piketage).Column("Piketag").Not.Nullable(); 
            Map(x => x.Limit).Not.Nullable(); 
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}