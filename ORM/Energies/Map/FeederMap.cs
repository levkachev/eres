using FluentNHibernate.Mapping;
using ORM.Energy.Entities;

namespace ORM.Energy.Map
{
    /// <summary>
    /// Фидер
    /// </summary>
    public class FeederMap : ClassMap<Feeder>
    {
        public FeederMap()
        {
            Table("Energy.Feeder");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            Map(x => x.FeederType).Length(45).Not.Nullable();
            Map(x => x.Piketage).Column("Piketag").Not.Nullable();
            Map(x => x.Resistance).Not.Nullable();
            References(x => x.PowerSupplyStation);
        }
    }
}
