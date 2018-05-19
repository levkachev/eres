using FluentNHibernate.Mapping;
using ORM.Energies.Entities;

namespace ORM.Energies.Map
{
    /// <summary>
    /// Сопротивление фидера
    /// </summary>
    public class ResistanceMap : ClassMap<Resistance>
    {
        public ResistanceMap()
        {
            Table("Energy.Resistance");
            Id(x => x.ID);
            Map(x => x.Length).Not.Nullable();
            Map(x => x.Square).Not.Nullable();
            Map(x => x.Count).Not.Nullable();         
            References(x => x.ResistanceType).Column(@"Type_Resistance");
            References(x => x.Feeder);
        }
    }
}
