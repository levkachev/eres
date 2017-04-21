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
            HasManyToMany(x => x.Station).Inverse();
            HasMany(x => x.NMLine);
            References(x => x.OpenLine);
            HasMany(x => x.PlanLine);
            HasMany(x => x.ProfileLine);
            HasMany(x => x.CurrentSectionLine);
            HasMany(x => x.LimitLine);
            References(x => x.ASRLine);
            HasMany(x => x.Stage);
        }

    }
}