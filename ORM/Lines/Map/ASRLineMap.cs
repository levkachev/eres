using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Автоматическое регулирование скорости. Данные по Линии
    /// </summary>
    public class ASRLineMap : ClassMap<ASRLine>
    {
        public ASRLineMap()
        {
            Table("Line.ASRLine");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            Map(x => x.Limit).Not.Nullable();
            Map(x => x.Piketage).Column("Piketag").Not.Nullable();
            References(x => x.Track).ForeignKey("ID_Track");
        }

    }
}