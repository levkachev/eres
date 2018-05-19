using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Цвет линии
    /// </summary>
    public class ColorMap : ClassMap<Color>
    {
        public ColorMap()
        {
            Table(@"Line.Color");
            Id(x => x.ID);
            Map(x => x.Name).Column(@"Colors").Length(45).Not.Nullable();
            Map(x => x.RGB).Column(@"RGBvalue");
            References(x => x.Line);
        }
    }
}
