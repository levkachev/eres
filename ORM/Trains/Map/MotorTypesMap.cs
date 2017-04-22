using ORM.Trains.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Trains.Map
{
    public class MotorTypesMap : ClassMap<MotorTypes>
    {
        public MotorTypesMap()
        {
            Table("Train.MotorType");
            Id(x => x.ID);
            Map(x => x.MotorType).Length(10).Not.Nullable().Unique();
            HasMany(x => x.ModeControls);


        }
    }
}
