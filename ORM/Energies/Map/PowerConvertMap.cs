using FluentNHibernate.Mapping;
using ORM.Energies.Entities;

namespace ORM.Energies.Map
{
    /// <summary>
    /// Справочник трансформаторов
    /// </summary>
    public class PowerConvertMap : ClassMap<PowerConvert>
    {
        public PowerConvertMap()
        {
            Table("Energy.PowerConvert");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            Map(x => x.Kt).Not.Nullable();
            Map(x => x.Pkz).Not.Nullable();
            Map(x => x.S).Not.Nullable();
            Map(x => x.U2).Not.Nullable();
        }
    }
}
