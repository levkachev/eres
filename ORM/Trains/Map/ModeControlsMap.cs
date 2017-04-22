using ORM.Trains.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Trains.Map
{
    public class ModeControlsMap: ClassMap<ModeControls>
    {
        public ModeControlsMap()
        {
            Table("Train.ModeControl");
            Id(x => x.ID);
            Map(x => x.ModeControl).Length(25).Not.Nullable();
            References(x => x.MotorType);
            HasMany(x => x.VFIs);

        }
    }
}

