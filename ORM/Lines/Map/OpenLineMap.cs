using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <inheritdoc />
    /// <summary>
    /// Открытые линии
    /// </summary>
    public class OpenLineMap : ClassMap<OpenLine>
    {
        public OpenLineMap()
        {
            Table(@"Line.OpenLine");
            Id(x => x.ID);
            Map(x => x.KWosn).Not.Nullable();
            Map(x => x.PiketageStart).Column(@"PiketagStart");
            Map(x => x.PiketageFinish).Column(@"PiketagFinish");
            HasMany(x => x.Tracks);
        }
    }
}
