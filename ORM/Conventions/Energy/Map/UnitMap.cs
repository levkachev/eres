using FluentNHibernate.Mapping;
using ORM.Energy.Entities;

namespace ORM.Energy.Map
{
    public class UnitMap : ClassMap<Unit>
    {
        public UnitMap()
        {
            Id(x => x.ID);
            Map(x => x.TransformatorCount).Not.Nullable();
            Map(x => x.UnitCount).Not.Nullable();
            Map(x => x.DioCount).Not.Nullable();
            //это предположения
            References(x => x.Unit_Name);
            References(x => x.PSS);
            HasMany(x => x.Diods);
            HasMany(x => x.PowerConverts);
        }
    }
}
