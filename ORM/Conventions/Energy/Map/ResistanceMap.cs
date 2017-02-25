using FluentNHibernate.Mapping;
using ORM.Energy.Entities;

namespace ORM.Energy.Map
{
    /// <summary>
    /// Сопротивление фидера
    /// </summary>
    public class ResistanceMap : ClassMap<Resistance>
    {
        public ResistanceMap()
        {
            Id(x => x.ID);
            Map(x => x.Length).Not.Nullable();
            Map(x => x.Square).Not.Nullable();
            Map(x => x.Count).Not.Nullable();
            //это предположения
            References(x => x.Type_Resistance);

            References(x => x.Feeder);
        }
    }
}
