using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Ограничения линий
    /// </summary>
    public class LimitLineMap : ClassMap<LimitLine>
    {
        public LimitLineMap()
        {
            Table("Line.LimitLine");
            Id(x => x.ID);
            Map(x => x.Piketage).Column("Piketag").Not.Nullable(); 
            Map(x => x.Limit).Not.Nullable(); 
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}