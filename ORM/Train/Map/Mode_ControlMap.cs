using ORM.Train.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Train.Map
{
    public class Mode_ControlMap: ClassMap<Mode_Control>
    {
        public Mode_ControlMap()
        {
            Table("Train.ModeControl");
            Id(x => x.ID);
            Map(x => x.ModeControl).Length(25).Not.Nullable();
            References(x => x.MotorType);

        }
    }
}

