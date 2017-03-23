using System;
using ORM.Base;

namespace ORM.Train.Entities
{
    /// <summary>
    /// Параметры поезда
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
        public virtual Double UnladenWeight { get; set; }

        /// <summary>
        /// Количество вагонов
        /// </summary>
        public virtual Int32 NumberCars { get; set; }

        /// <summary>
        /// номинальное напряжение
        /// </summary>
        public virtual Double Unom { get; set; }

        /// <summary>
        /// for AC максимальное напряжение
        /// </summary>
        public virtual Double Umax { get; set; }

        /// <summary>
        /// Среднее замедление
        /// </summary>
        public virtual Double BAverage { get; set; }

        /// <summary>
        /// 1-коэффициент основного сопротивления для тяги
        /// </summary>
        public virtual Double NetResistencePullFactor { get; set; }

        /// <summary>
        /// Коэффициент аэродинамического сопротивления
        /// </summary>
        public virtual Double AerodynamicDragFactor { get; set; }

        /// <summary>
        /// 1-коэффициент основного сопротивления для выбега
        /// </summary>
        public virtual Double NetResistenceCoastingFactor1 { get; set; }

        /// <summary>
        /// 2-коэффициент основного сопротивления для выбега
        /// </summary>
        public virtual Double NetResistenceCoastingFactor2 { get; set; }

        /// <summary>
        /// 3-коэффициент основного сопротивления для выбега
        /// </summary>
        public virtual Double NetResistenceCoastingFactor3 { get; set; }

        /// <summary>
        /// эквивалентная поверхность состава
        /// </summary>
        public virtual Double TrainEqvivalentSurface { get; set; }

        /// <summary>
        /// Коэффициент инерции вращающихся масс
        /// </summary>
        public virtual Double InertiaRotationFactor { get; set; }

        /// <summary>
        /// Время коммутации силовой цепи
        /// </summary>
        public virtual Double AssemblyPowerCircuitTime { get; set; }

        /// <summary>
        /// Время разбора силовой цепи
        /// </summary>
        public virtual Double DisassemblyPowerCircuitTime { get; set; }

        /// <summary>
        /// Время сбора силовой цепи на ход
        /// </summary>
        public virtual Double AssemblyPullTime { get; set; }

        /// <summary>
        /// Сопротивление разбора режима ход
        /// </summary>
        public virtual Double AssemblyPullResistance { get; set; }

        /// <summary>
        /// Время сбора силовой цепи на Тормоз
        /// </summary>
        public virtual Double AssemblyBreakTime { get; set; }

        /// <summary>
        /// Сопротивление разбора режима Тормоз
        /// </summary>
        public virtual Double AssemblyBreakResistance { get; set; }

        /// <summary>
        /// Сопротивление обмотки якоря
        /// </summary>
        public virtual Double AnchorResistance { get; set; }

        /// <summary>
        /// Сопротивление главных полюсов
        /// </summary>
        public virtual Double MainPoleResistance { get; set; }

        /// <summary>
        /// Сопротивление дополнительных полюсов
        /// </summary>
        public virtual Double CompolesResistance { get; set; }

        /// <summary>
        /// 1-ый Коэффициент авторежима
        /// </summary>
        public virtual Double AutomodeFactor1 { get; set; }

        /// <summary>
        /// 2-ой Коэффициент авторежима
        /// </summary>
        public virtual Double AutomodeFactor2 { get; set; }

        /// <summary>
        /// 1-ый Коэффициент расчета времени возбуждения
        /// </summary>
        public virtual Double ExcitationTimeFactor1 { get; set; }

        /// <summary>
        /// 2-ой Коэффициент расчета времени возбуждения
        /// </summary>
        public virtual Double ExcitationTimeFactor2 { get; set; }

        /// <summary>
        /// 3-й Коэффициент расчета времени возбуждения
        /// </summary>
        public virtual Double ExcitationTimeFactor3 { get; set; }

        /// <summary>
        /// Максимальное время возбуждения
        /// </summary>
        public virtual Double MaxExcitationTime { get; set; }

        /// <summary>
        /// Нижняя граница авторежима
        /// </summary>
        public virtual Double LowAutoModeRange { get; set; }

        /// <summary>
        /// Верхняя граница авторежима
        /// </summary>
        public virtual Double HighAutoModeRange { get; set; }

        /// <summary>
        /// Время линейного нарастания тока
        /// </summary>
        public virtual Double LinearGrowCurrentTime { get; set; }

        /// <summary>
        /// Схема соединения на Ход2
        /// </summary>
        public virtual Int32 ConnectionPull2 { get; set; }

        /// <summary>
        /// Позиция РК для Хода2
        /// </summary>
        public virtual Int32 PositionPull2 { get; set; }

        /// <summary>
        /// Удельный расход электроэнергии на собственные нужды
        /// </summary>
        public virtual Double OwnNeedsElectricPower { get; set; }

        /// <summary>
        /// Учет вагонов тяги
        /// </summary>
        public virtual Int32 nbAuto { get; set; }

        /// <summary>
        /// OslX2
        /// </summary>
        public virtual Int32 WeakPull2 { get; set; }

        /// <summary>
        /// Наименование поезда
        /// </summary>
        public virtual Train_Name TrainName { get; set; }
    }
}
