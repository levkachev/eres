using ORM.Trains.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Trains.Map
{
    public class MotorTypeMap : ClassMap<MotorType>
    {
        public MotorTypeMap()
        {
            Table(@"Train.MotorType");
            Id(x => x.ID);
            Map(x => x.Name).Column(@"MotorType").Length(10).Not.Nullable().Unique();
            HasMany(x => x.ModeControls);
        }
    }
}
