using FluentNHibernate.Mapping;
using ORM.Energies.Entities;

namespace ORM.Energies.Map
{
    /// <summary>
    /// Справочник выпрямителей
    /// </summary>
    public class DiodeMap :  ClassMap<Diode>
    {
       public DiodeMap()
        {
            Table(@"Energy.Diod");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            Map(x => x.Rdmax).Not.Nullable();
            Map(x => x.Rdmin).Not.Nullable();
            Map(x => x.U0).Not.Nullable();
        }
    }
}
