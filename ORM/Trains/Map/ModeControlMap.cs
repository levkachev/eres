using ORM.Trains.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Trains.Map
{
    public class ModeControlMap : ClassMap<ModeControl>
    {
        public ModeControlMap()
        {
            Table(@"Train.ModeControl");
            Id(x => x.ID);
            Map(x => x.Name).Column(@"ModeControl").Length(25).Not.Nullable();
            References(x => x.MotorType);
            HasMany(x => x.Characteristics).KeyColumn(@"VFIs");
        }
    }
}

