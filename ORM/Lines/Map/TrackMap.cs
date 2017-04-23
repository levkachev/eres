using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Путь
    /// </summary>
    public class TrackMap : ClassMap<Track>
    {
        public TrackMap()
        {
            Table("Line.Track");
            Id(x => x.ID);
            Map(x => x.Tracks).Column("Track");
            References(x => x.Line).ForeignKey("ID_Line");
            HasMany(x => x.NMLines);
            HasMany(x => x.OpenLines);
            HasMany(x => x.PlanLines);
            HasMany(x => x.ProfileLines);
            HasMany(x => x.CurrentSectionLines);
            HasMany(x => x.LimitLines);
            HasMany(x => x.ASRLines);
            HasMany(x => x.Stages);
        }

    }
}