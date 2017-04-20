using FluentNHibernate.Mapping;

namespace ORM.Lines.Map
{
    /// <summary>
    /// 
    /// </summary>
    public class LineMap : ClassMap<Entities.Line>
    {
        /// <summary>
        /// 
        /// </summary>
        public LineMap()
        {
            Table("Line.Line");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            References(x => x.Color);
            HasMany(x => x.PowerSupplyStation);
            HasMany(x => x.Track);
            HasMany(x => x.Direction);
        }
    }
}
