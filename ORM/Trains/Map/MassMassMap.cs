using ORM.Trains.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Trains.Map
{
    public class MassMassMap : ClassMap<MassMass>
    {
        public MassMassMap()
        {
            Table("Train.Mass");
            Id(x => x.ID);
            Map(x => x.Mass).Not.Nullable().Unique();
            
        }
    }
}
