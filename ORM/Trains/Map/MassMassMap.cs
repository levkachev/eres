using ORM.Train.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Train.Map
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
