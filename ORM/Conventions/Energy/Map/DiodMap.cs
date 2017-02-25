using FluentNHibernate.Mapping;
using ORM.Energy.Entities;

namespace ORM.Energy.Map
{
    /// <summary>
    /// Справочник выпрямителей
    /// </summary>
    public class DiodMap :  ClassMap<Diod>
    {
       public DiodMap()
        {
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            Map(x => x.Rdmax).Not.Nullable();
            Map(x => x.Rdmin).Not.Nullable();
            Map(x => x.U0).Not.Nullable();
        }
    }
}
