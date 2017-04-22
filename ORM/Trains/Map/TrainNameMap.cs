using ORM.Trains.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Trains.Map
{
    public class TrainNameMap : ClassMap<TrainName>
    {
        public TrainNameMap()
        {
            Table("Train.TrainName");
            Id(x => x.ID);
            Map(x => x.Name).Length(25).Not.Nullable();
            References(x => x.MotorType);
            HasMany(x => x.VFIs);
            HasMany(x => x.АdditionalParameters);

        }
    }
}