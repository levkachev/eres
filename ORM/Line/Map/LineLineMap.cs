using FluentNHibernate.Mapping;
using ORM.Line.Entities;

namespace ORM.Line.Map
{
    public class LineLineMap : ClassMap<LineLine>
    {
        public LineLineMap()
        {
            Table("Line.Line");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            References(x => x.Color);
        }
    }
}
