using FluentNHibernate.Mapping;
using ORM.Energy.Entities;

namespace ORM.Energy.Map
{
    /// <summary>
    /// Справочник агрегатов
    /// </summary>
    public class Unit_NameMap : ClassMap<Unit_Name>
    {
        public Unit_NameMap()
        {
            Table("Energy.Unit_Name");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
        }
    }
}
