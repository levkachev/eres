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
            Map(x => x.Piketage_Start).Column("Piketag_Start").Not.Nullable();
            Map(x => x.Piketage_Finish).Column("Piketag_Finish").Not.Nullable();
            References(x => x.Line).ForeignKey("ID_Line");
           
        }

    }
}
