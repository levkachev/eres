using FluentNHibernate.Mapping;
using ORM.Energy.Entities;

namespace ORM.Energy.Map
{
    /// <summary>
    /// Тяговые подстанции
    /// </summary>
    public class PowerSupplyStationMap : ClassMap<PowerSupplyStation>
    {
        /// <summary>
        /// 
        /// </summary>
        public PowerSupplyStationMap()
        {
            Table("Energy.PowerSupplyStation");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            Map(x => x.Piketage).Column("Piketag").Not.Nullable();
            References(x => x.Line).ForeignKey("ID_Line");
            HasMany(x => x.Feeders);
            HasMany(x => x.Units);
        }

     
    }
}
