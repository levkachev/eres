using ORM.Train.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Train.Map
{
    public class Motor_TypeMap : ClassMap<Motor_Type>
    {
        public Motor_TypeMap()
        {
            Table("Train.MotorType");
            Id(x => x.ID);
            Map(x => x.MotorType).Length(10).Not.Nullable().Unique();
           

        }
    }
}
