using FluentNHibernate.Mapping;
using ORM.Energy.Entities;

namespace ORM.Energy.Map
{
    /// <summary>
    /// Фидер
    /// </summary>
    public class FeederMap : ClassMap<Feeder>
    {
        public FeederMap()
        {
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable();
            Map(x => x.Feeder_Type).Length(45).Not.Nullable();
            Map(x => x.Piketag).Not.Nullable();
            Map(x => x.Resistance).Not.Nullable();
            //это как предположение
            References(x => x.PSS);
        }
    }
}
