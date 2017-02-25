using FluentNHibernate.Mapping;
using ORM.Line.Entities;

namespace ORM.Line.Map
{
    public class LineMap : ClassMap<Line.Entities.Line>
    {
        public LineMap()
        {
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            References(x => x.Color);
        }
    }
}
