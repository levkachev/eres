using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Открытые линии
    /// </summary>
    public class OpenLineMap : ClassMap<OpenLine>
    {
        public OpenLineMap()
        {
            Table("Line.OpenLine");
            Id(x => x.ID);
            Map(x => x.KWosn).Not.Nullable();
            Map(x => x.Piketage_Start).Column("Piketag_Start");
            Map(x => x.Piketage_Finish).Column("Piketag_Finish");
            HasMany(x => x.Track);

        }

    }
}
