using FluentNHibernate.Mapping;
using ORM.Energy.Entities;

namespace ORM.Energy.Map
{
    /// <summary>
    /// Тяговые подстанции
    /// </summary>
    public class PowerSupplyStationMap : ClassMap<PowerSupplyStation>
    {
        public PowerSupplyStationMap()
        {
            Table("Energy.PowerSupplyStation");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            Map(x => x.Piketag).Not.Nullable();
            References(x => x.Line);
        }

     
    }
}
