using System;
using ORM.Base;

namespace ORM.Train.Entities
{
    /// <summary>
    /// параметры поезда
    /// </summary>
    public class АdditionalParameter : Entity<АdditionalParameter>
    {
        /// <summary>
        /// Длина вагона
        /// </summary>
        public virtual Double CarLength { get; set; }

        /// <summary>
        /// Масса порожнего вагона
        /// </summary>
        public virtual Double Unladen_Weight { get; set; }

        /// <summary>
        /// Количество вагонов
        /// </summary>
        public virtual Int32 Number_Cars { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Double Unom { get; set; }

        /// <summary>
        /// for AC
        /// </summary>
        public virtual Double Umax { get; set; }

        /// <summary>
        /// Среднее замедление
        /// </summary>
        public virtual Double BAverage { get; set; }

        /// <summary>
        /// 1-коэффициент основного сопротивления для тяги
        /// </summary>
        public virtual Double Net_Resistence_Pull_Factor { get; set; }

        /// <summary>
        /// коэффициент аэродинамического сопротивления
        /// </summary>
        public virtual Double Aerodynamic_Drag_Factor { get; set; }

        /// <summary>
        /// 1-коэффициент основного сопротивления для выбега
        /// </summary>
        public virtual Double Net_Resistence_Coasting_Factor1 { get; set; }

        /// <summary>
        /// 2-коэффициент основного сопротивления для выбега
        /// </summary>
        public virtual Double Net_Resistence_Coasting_Factor2 { get; set; }

        /// <summary>
        /// 3-коэффициент основного сопротивления для выбега
        /// </summary>
        public virtual Double Net_Resistence_Coasting_Factor3 { get; set; }

        /// <summary>
        /// эквивалентная поверхность состава
        /// </summary>
        public virtual Double Train_Eqvivalent_Surface { get; set; }

        /// <summary>
        /// Коэффициент инерции вращающихся масс
        /// </summary>
        public virtual Double Inertia_Rotation_Factor { get; set; }

        /// <summary>
        /// Время коммутации силовой цепи
        /// </summary>
        public virtual Double Assembly_PowerCircuit_Time { get; set; }

        /// <summary>
        /// Время разбора силовой цепи
        /// </summary>
        public virtual Double Disassembly_PowerCircuit_Time { get; set; }

        /// <summary>
        /// Время сбора силовой цепи на ход
        /// </summary>
        public virtual Double Assembly_Pull_Time { get; set; }

        /// <summary>
        /// Сопротивление разбора режима ход
        /// </summary>
        public virtual Double Assembly_Pull_Resistance { get; set; }

        /// <summary>
        /// Время сбора силовой цепи на Тормоз
        /// </summary>
        public virtual Double Assembly_Break_Time { get; set; }

        /// <summary>
        /// Сопротивление разбора режима Тормоз
        /// </summary>
        public virtual Double Assembly_Break_Resistance { get; set; }

        /// <summary>
        /// Сопротивление обмотки якоря
        /// </summary>
        public virtual Double Anchor_Resistance { get; set; }

        /// <summary>
        /// Сопротивление главных полюсов
        /// </summary>
        public virtual Double Main_Pole_Resistance { get; set; }

        /// <summary>
        /// Сопротивление дополнительных полюсов
        /// </summary>
        public virtual Double Compoles_Resistance { get; set; }

        /// <summary>
        /// 1-ый Коэффициент авторежима
        /// </summary>
        public virtual Double Automode_Factor1 { get; set; }

        /// <summary>
        /// 2-ой Коэффициент авторежима
        /// </summary>
        public virtual Double Automode_Factor2 { get; set; }

        /// <summary>
        /// 1-ый Коэффициент расчета времени возбуждения
        /// </summary>
        public virtual Double Excitation_Time_Factor1 { get; set; }

        /// <summary>
        /// 2-ой Коэффициент расчета времени возбуждения
        /// </summary>
        public virtual Double Excitation_Time_Factor2 { get; set; }

        /// <summary>
        /// 3-й Коэффициент расчета времени возбуждения
        /// </summary>
        public virtual Double Excitation_Time_Factor3 { get; set; }

        /// <summary>
        /// Максимальное время возбуждения
        /// </summary>
        public virtual Double Max_Excitation_Time { get; set; }

        /// <summary>
        /// Нижняя граница авторежима
        /// </summary>
        public virtual Double Low_AutoMode_Range { get; set; }

        /// <summary>
        /// Верхняя граница авторежима
        /// </summary>
        public virtual Double High_AutoMode_Range { get; set; }

        /// <summary>
        /// Время линейного нарастания тока
        /// </summary>
        public virtual Double Linear_Grow_Current_Time { get; set; }

        /// <summary>
        /// Схема соединения на Ход2
        /// </summary>
        public virtual Int32 Connection_Pull2 { get; set; }

        /// <summary>
        /// Позиция РК для Хода2
        /// </summary>
        public virtual Int32 Position_Pull2 { get; set; }

        /// <summary>
        /// Удельный расход электроэнергии на собственные нужды
        /// </summary>
        public virtual Double Own_Needs_Electric_Power { get; set; }

        /// <summary>
        /// Учет вагонов тяги
        /// </summary>
        public virtual Int32 nbAuto { get; set; }

        /// <summary>
        /// OslX2
        /// </summary>
        public virtual Int32 Weak_Pull2 { get; set; }

        /// <summary>
        /// Наименование поезда
        /// </summary>
        public virtual Train_Name TrainName { get; set; }
    }
}
