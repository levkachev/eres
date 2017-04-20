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
            HasMany(x => x.NM_Line);
            HasMany(x => x.Open_Line);
            HasMany(x => x.Plan_Line);
            HasMany(x => x.Profil_Line);
            HasMany(x => x.Current_Section);
            HasMany(x => x.Limit_Line);
        }

    }
}