using FluentNHibernate.Mapping;
using ORM.Line.Entities;

namespace ORM.Line.Map
{
    /// <summary>
    /// Цвет линии
    /// </summary>
    public class ColorMap : ClassMap<Color>
    {
        public ColorMap()
        {
            Table("Line.Color");
            Id(x => x.ID);
            Map(x => x.Colors).Length(45).Not.Nullable();
            Map(x => x.RGBvalue);
        }
    }
}
