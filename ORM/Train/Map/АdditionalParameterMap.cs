using ORM.Train.Entities;
using FluentNHibernate.Mapping;

namespace ORM.Train.Map
{
    public class АdditionalParameterMap : ClassMap<АdditionalParameter>
    {
        public АdditionalParameterMap ()
        {
            Table("Train.АdditionalParameterMap");
            Id(x => x.ID);
            Map(x => x.CarLength).Not.Nullable();
            Map(x => x.Unladen_Weight).Not.Nullable();
            Map(x => x.Number_Cars).Not.Nullable();
            Map(x => x.Unom).Not.Nullable();
            Map(x => x.Umax).Not.Nullable();
            Map(x => x.BAverage).Not.Nullable();
            Map(x => x.Net_Resistence_Pull_Factor).Not.Nullable();
            Map(x => x.Aerodynamic_Drag_Factor).Not.Nullable();
            Map(x => x.Net_Resistence_Coasting_Factor1).Not.Nullable();
            Map(x => x.Net_Resistence_Coasting_Factor2).Not.Nullable();
            Map(x => x.Net_Resistence_Coasting_Factor3).Not.Nullable();
            Map(x => x.Train_Eqvivalent_Surface).Not.Nullable();
            Map(x => x.Inertia_Rotation_Factor);
            Map(x => x.Assembly_PowerCircuit_Time);
            Map(x => x.Disassembly_PowerCircuit_Time).Not.Nullable();
            Map(x => x.Assembly_Pull_Time).Not.Nullable();
            Map(x => x.Assembly_Pull_Resistance);
            Map(x => x.Assembly_Break_Time).Not.Nullable();
            Map(x => x.Assembly_Break_Resistance);
            Map(x => x.Anchor_Resistance);
            Map(x => x.Main_Pole_Resistance);
            Map(x => x.Compoles_Resistance);
            Map(x => x.Automode_Factor1);
            Map(x => x.Automode_Factor2);
            Map(x => x.Excitation_Time_Factor1);
            Map(x => x.Excitation_Time_Factor2);
            Map(x => x.Excitation_Time_Factor3);
            Map(x => x.Max_Excitation_Time);
            Map(x => x.Low_AutoMode_Range);
            Map(x => x.High_AutoMode_Range);
            Map(x => x.Linear_Grow_Current_Time);
            Map(x => x.Connection_Pull2);
            Map(x => x.Position_Pull2);
            Map(x => x.Own_Needs_Electric_Power).Not.Nullable();
            Map(x => x.nbAuto);
            Map(x => x.Weak_Pull2);
            References(x => x.TrainName);
           

        }
    }
}