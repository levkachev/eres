using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// направление
    /// </summary>
    public class DirectionMap : ClassMap<Direction>
    {
        public DirectionMap()
        {
            Table("Line.Direction");
            Id(x => x.ID);
            Map(x => x.Directions).Column("Direction");
            Map(x => x.PiketageStart).Column("PiketagStart").Not.Nullable();
            Map(x => x.PiketageFinish).Column("PiketagFinish").Not.Nullable();
            References(x => x.Line).ForeignKey("ID_Line");
           
        }

    }
}
