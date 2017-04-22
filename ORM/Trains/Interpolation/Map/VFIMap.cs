using ORM.Trains.Interpolation.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Trains.Interpolation.Map
{
    public class VFIMap : ClassMap<VFI>
    {
        public VFIMap()
        {
            Table("Train.VFI");
            Id(x => x.ID);
            Map(x => x.Velocity).Not.Nullable();
            Map(x => x.CurrentMax).Not.Nullable();
            Map(x => x.CurrentMin).Not.Nullable();
            Map(x => x.ForceMax).Not.Nullable();
            Map(x => x.ForceMin).Not.Nullable();
            References(x => x.Mass);
            References(x => x.ModeControl);
            References(x => x.Train);


        }
    }
}