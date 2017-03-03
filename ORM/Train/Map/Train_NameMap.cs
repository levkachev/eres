using ORM.Train.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Train.Map
{
    public class Train_NameMap : ClassMap<Train_Name>
    {
        public Train_NameMap()
        {
            Table("Train.Train_Name");
            Id(x => x.ID);
            Map(x => x.Name).Length(25).Not.Nullable();
            References(x => x.MotorType);

        }
    }
}