using FluentNHibernate.Mapping;
using ORM.Lines.Entities;

namespace ORM.Lines.Map
{
    /// <summary>
    /// Станция
    /// </summary>
    public class StationMap : ClassMap<Station>
    {
        public StationMap()
        {
            Table("Line.Station");
            Id(x => x.ID);
            Map(x => x.Name).Length(45).Not.Nullable(); 
            Map(x => x.Piketage).Column("Piketag").Not.Nullable();
            Map(x => x.ShortName).Length(20);
            References(x => x.Line);
          //  References(x => x.Arrival); 
          //  References(x => x.Departure);

        }

    }
}