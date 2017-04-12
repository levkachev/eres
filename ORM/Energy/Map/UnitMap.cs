using FluentNHibernate.Mapping;
using ORM.Energy.Entities;

namespace ORM.Energy.Map
{
    public class UnitMap : ClassMap<Unit>
    {
        public UnitMap()
        {
            Table("Energy.Unit");
            Id(x => x.ID);
            Map(x => x.TransformatorCount).Not.Nullable();
            Map(x => x.UnitCount).Not.Nullable();
            Map(x => x.DiodCount).Not.Nullable();
           
            References(x => x.Unit_Name);
            References(x => x.PowerSupplyStation);
            HasMany(x => x.Diods);
            HasMany(x => x.PowerConverts);
        }
    }
}
