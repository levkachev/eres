using ORM.Trains.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Trains.Map
{
    public class АdditionalParameterMap : ClassMap<AdditionalParameter>
    {
        public АdditionalParameterMap ()
        {
            Table("[Train].[АdditionalParameter]");
            Id(x => x.ID);
            Map(x => x.CarLength).Not.Nullable();
            Map(x => x.UnladenWeight).Not.Nullable();
            Map(x => x.NumberCars).Not.Nullable();
            Map(x => x.Unom).Not.Nullable();
            Map(x => x.Umax).Not.Nullable();
            Map(x => x.BAverage).Not.Nullable();
            Map(x => x.NetResistencePullFactor).Not.Nullable();
            Map(x => x.AerodynamicDragFactor).Not.Nullable();
            Map(x => x.NetResistenceCoastingFactor1).Not.Nullable();
            Map(x => x.NetResistenceCoastingFactor2).Not.Nullable();
            Map(x => x.NetResistenceCoastingFactor3).Not.Nullable();
            Map(x => x.TrainEqvivalentSurface).Not.Nullable();
            Map(x => x.InertiaRotationFactor);
            Map(x => x.AssemblyPowerCircuitTime);
            Map(x => x.DisassemblyPowerCircuitTime).Not.Nullable();
            Map(x => x.AssemblyPullTime).Not.Nullable();
            Map(x => x.AssemblyPullResistance);
            Map(x => x.AssemblyBreakTime).Not.Nullable();
            Map(x => x.AssemblyBreakResistance);
            Map(x => x.AnchorResistance);
            Map(x => x.MainPoleResistance);
            Map(x => x.CompolesResistance);
            Map(x => x.AutomodeFactor1);
            Map(x => x.AutomodeFactor2);
            Map(x => x.ExcitationTimeFactor1);
            Map(x => x.ExcitationTimeFactor2);
            Map(x => x.ExcitationTimeFactor3);
            Map(x => x.MaxExcitationTime);
            Map(x => x.LowAutoModeRange);
            Map(x => x.HighAutoModeRange);
            Map(x => x.LinearGrowCurrentTime);
            Map(x => x.ConnectionPull2);
            Map(x => x.PositionPull2);
            Map(x => x.OwnNeedsElectricPower).Not.Nullable();
            Map(x => x.nbAuto);
            Map(x => x.WeakPull2);
            References(x => x.TrainName);
           

        }
    }
}