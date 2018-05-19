using ORM.Trains.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Trains.Map
{
    public class MassMap : ClassMap<Mass>
    {
        public MassMap()
        {
            Table(@"Train.Mass");
            Id(x => x.ID);
            Map(x => x.Value).Column(@"Mass").Not.Nullable().Unique();
            HasMany(x => x.Characteristics).KeyColumn(@"VFIs");
        }
    }
}
