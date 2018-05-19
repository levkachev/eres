using FluentNHibernate.Mapping;
using ORM.Energies.Entities;

namespace ORM.Energies.Map
{
    /// <inheritdoc />
    /// <summary>
    /// Справочник агрегатов
    /// </summary>
    public class NamedUnitMap : ClassMap<NamedUnit>
    {
        public NamedUnitMap()
        {
            Table(@"Energy.Unit_Name");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
        }
    }
}
