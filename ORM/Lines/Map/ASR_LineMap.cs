using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Автоматическое регулирование скорости. Данные по Линии
    /// </summary>
    public class ASR_LineMap : ClassMap<ASR_Line>
    {
        public ASR_LineMap()
        {
            Table("Line.ASR_Line");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            Map(x => x.Limit).Not.Nullable();
            Map(x => x.Piketage).Column("Piketag").Not.Nullable();
            References(x => x.Track).ForeignKey("ID_Track");
        }

    }
}