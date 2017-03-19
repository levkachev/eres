using System;

namespace TrainMovement.Machine
{
    [Serializable]
    public class DCMachine    : BaseMachine
    {
        /// <summary>
        /// FLOAT --Время коммутации силовой цепи tkom
        /// </summary>
        public Double AssemblyPowerCircuitTime { get; protected set; }

        /// <summary>
        /// FLOAT --Сопротивление разбора режима ход rrasbp
        /// </summary>
        public Double AssemblyPullResistance { get; protected set; }

        /// <summary>
        /// FLOAT--Сопротивление разбора режима Тормоз rrasbB
        /// </summary>
        public Double AssemblyBreakResistance { get; protected set; }

        /// <summary>
        /// FLOAT--Сопротивление обмотки якоря rd
        /// </summary>
        public Double AnchorResistance { get; protected set; }

        /// <summary>
        /// FLOAT --Сопротивление главных полюсов rpg
        /// </summary>
        public Double MainPoleResistance { get; protected set; }

        /// <summary>
        /// FLOAT--Сопротивление дополнительных полюсов rpd
        /// </summary>
        public Double CompolesResistance { get; protected set; }

        /// <summary>
        /// FLOAT--1-ый Коэффициент авторежима kar1
        /// </summary>
        public Double AutomodeFactor1 { get; protected set; }

        /// <summary>
        /// FLOAT --2-й Коэффициент авторежима kar2
        /// </summary>
        public Double AutomodeFactor2 { get; protected set; }

        /// <summary>
        /// FLOAT -- 1-ый Коэффициент расчета времени возбуждения ktw1
        /// </summary>
        public Double ExcitationTimeFactor1 { get; protected set; }

        /// <summary>
        /// FLOAT -- 2-й Коэффициент расчета времени возбуждения ktw2
        /// </summary>
        public Double ExcitationTimeFactor2 { get; protected set; }

        /// <summary>
        /// FLOAT -- 3-й Коэффициент расчета времени возбуждения ktw3
        /// </summary>
        public Double ExcitationTimeFactor3 { get; protected set; }

        /// <summary>
        /// FLOAT --Максимальное время возбуждения TWmax
        /// </summary>
        public Double MaxExcitationTime { get; protected set; }

        /// <summary>
        /// FLOAT --Нижняя граница авторежима qar1
        /// </summary>
        public Double LowAutoModeRange { get; protected set; }

        /// <summary>
        /// FLOAT --Верхняя граница авторежима qar2
        /// </summary>
        public Double HighAutoModeRange { get; protected set; }

        /// <summary>
        /// FLOAT --Время линейного нарастания тока tlin
        /// </summary>
        public Double LinearGrowCurrentTime { get; protected set; }

        /// <summary>
        /// INT--Схема соединения на Ход2 kreis2
        /// </summary>
        public Int32 ConnectionPull2 { get; protected set; }

        /// <summary>
        /// INT --Позиция РК для Хода2 position2
        /// </summary>
        public Int32 PositionPull2 { get; protected set; }

        /// <summary>
        /// INT
        /// </summary>
        public Int32 NbAuto { get; protected set; }

        /// <summary>
        /// INT --OslX2
        /// </summary>
        public Boolean WeakPull2 { get; protected set; }
    }
}
