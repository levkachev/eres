using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Профиль линии
    /// </summary>
    public class ProfileLineMap : ClassMap<ProfileLine>
    {
        public ProfileLineMap()
        {
            Table("Line.ProfileLine");
            Id(x => x.ID);
            Map(x => x.Slope).Not.Nullable();
            Map(x => x.Piketage).Column("Piketag").Not.Nullable();
            References(x => x.Track).ForeignKey("ID_Track");

        }

    }
}