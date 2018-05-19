using FluentNHibernate.Mapping;
using ORM.Energies.Entities;

namespace ORM.Energies.Map
{
    /// <summary>
    /// Справочник кабелей
    /// </summary>
    public class ResistanceTypeMap: ClassMap<ResistanceType>
    {
        public ResistanceTypeMap()
        {
            Table(@"Energy.Type_Resistance");
            Id(x => x.ID);
            Map(x => x.Resistance).Not.Nullable();
            Map(x => x.Name).Column(@"Type").Length(45).Not.Nullable();
        }
    }
}
