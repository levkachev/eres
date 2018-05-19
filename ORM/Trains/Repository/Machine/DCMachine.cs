using System;

namespace ORM.Trains.Repository.Machine
{
    /// <summary>
    /// Параметры для DC двигателя 
    /// </summary>
    public class DCMachine : BaseMachine
    {

        /// <summary>
        /// 
        /// </summary>
        private Double assemblyPowerCircuitTime;

        /// <summary>
        /// 
        /// </summary>
        private Double assemblyPullResistance;

        /// <summary>
        /// 
        /// </summary>
        private Double assemblyBreakResistance;

        /// <summary>
        /// 
        /// </summary>
        private Double anchorResistance;

        /// <summary>
        /// 
        /// </summary>
        private Double mainPoleResistance;

        /// <summary>
        /// 
        /// </summary>
        private Double comPolesResistance;

        /// <summary>
        /// 
        /// </summary>
        private Double autoModeFactor1;

        /// <summary>
        /// 
        /// </summary>
        private Double autoModeFactor2;

        /// <summary>
        /// 
        /// </summary>
        private Double excitationTimeFactor1;

        /// <summary>
        /// 
        /// </summary>
        private Double excitationTimeFactor2;

        /// <summary>
        /// 
        /// </summary>
        private Double excitationTimeFactor3;

        /// <summary>
        /// 
        /// </summary>
        private Double maxExcitationTime;

        /// <summary>
        /// 
        /// </summary>
        private Double lowAutoModeRange;

        /// <summary>
        /// 
        /// </summary>
        private Double highAutoModeRange;

        /// <summary>
        /// 
        /// </summary>
        private Double linearGrowCurrentTime;

        /// <summary>
        /// 
        /// </summary>
        private Int32 connectionPull2;

        /// <summary>
        /// 
        /// </summary>
        private Int32 positionPull2;

        /// <summary>
        /// 
        /// </summary>
        private Int32 weakPull2;

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">
        /// value < zero.
        /// </exception>
        public Double AssemblyPowerCircuitTime
        {
            get { return assemblyPowerCircuitTime; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                assemblyPowerCircuitTime = value;
            }
        }

        /// <summary>
        /// FLOAT --Сопротивление разбора режима ход rrasbp
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double AssemblyPullResistance
        {
            get { return assemblyPullResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                assemblyPullResistance = value;
            }
        }

        /// <summary>
        /// FLOAT--Сопротивление разбора режима Тормоз rrasbB
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double AssemblyBreakResistance
        {
            get { return assemblyBreakResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                assemblyBreakResistance = value;
            }
        }

        /// <summary>
        /// FLOAT--Сопротивление обмотки якоря rd
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double AnchorResistance
        {
            get { return anchorResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                anchorResistance = value;
            }
        }

        /// <summary>
        /// FLOAT --Сопротивление главных полюсов rpg
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double MainPoleResistance
        {
            get { return mainPoleResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                mainPoleResistance = value;
            }
        }

        /// <summary>
        /// FLOAT--Сопротивление дополнительных полюсов rpd
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double ComPolesResistance
        {
            get { return comPolesResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                comPolesResistance = value;
            }
        }

        /// <summary>
        /// FLOAT--1-ый Коэффициент авторежима kar1
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double AutoModeFactor1
        {
            get { return autoModeFactor1; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                autoModeFactor1 = value;
            }
        }

        /// <summary>
        /// FLOAT --2-й Коэффициент авторежима kar2
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double AutoModeFactor2
        {
            get { return autoModeFactor2; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                autoModeFactor2 = value;
            }
        }

        /// <summary>
        /// FLOAT -- 1-ый Коэффициент расчета времени возбуждения ktw1
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double ExcitationTimeFactor1
        {
            get { return excitationTimeFactor1; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                excitationTimeFactor1 = value;
            }
        }

        /// <summary>
        /// FLOAT -- 2-й Коэффициент расчета времени возбуждения ktw2
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double ExcitationTimeFactor2
        {
            get { return excitationTimeFactor2; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                excitationTimeFactor2 = value;
            }
        }

        /// <summary>
        /// FLOAT -- 3-й Коэффициент расчета времени возбуждения ktw3
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double ExcitationTimeFactor3
        {
            get { return excitationTimeFactor3; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                excitationTimeFactor3 = value;
            }
        }

        /// <summary>
        /// FLOAT --Максимальное время возбуждения TWmax
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double MaxExcitationTime
        {
            get { return maxExcitationTime; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                maxExcitationTime = value;
            }
        }

        /// <summary>
        /// FLOAT --Нижняя граница авторежима qar1
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double LowAutoModeRange
        {
            get { return lowAutoModeRange; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                lowAutoModeRange = value;
            }
        }

        /// <summary>
        /// FLOAT --Верхняя граница авторежима qar2
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double HighAutoModeRange
        {
            get { return highAutoModeRange; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                highAutoModeRange = value;
            }
        }

        /// <summary>
        /// FLOAT --Время линейного нарастания тока tlin
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double LinearGrowCurrentTime
        {
            get { return linearGrowCurrentTime; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                linearGrowCurrentTime = value;
            }
        }

        /// <summary>
        /// INT--Схема соединения на Ход2 kreis2
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Int32 ConnectionPull2
        {
            get { return connectionPull2; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                connectionPull2 = value;
            }
        }

        /// <summary>
        /// INT --Позиция РК для Хода2 position2
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Int32 PositionPull2
        {
            get { return positionPull2; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                positionPull2 = value;
            }
        }


        /// <summary>
        /// INT --OslX2
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Int32 WeakPull2
        {
            get { return weakPull2; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                weakPull2 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disassemblyPowerCircuitTime"></param>
        /// <param name="positionPull2"></param>
        /// <param name="weakPull2"></param>
        /// <param name="assemblyPullTime"></param>
        /// <param name="trainName"></param>
        /// <param name="assemblyPowerCircuitTime"></param>
        /// <param name="assemblyPullResistance"></param>
        /// <param name="assemblyBreakResistance"></param>
        /// <param name="anchorResistance"></param>
        /// <param name="mainPoleResistance"></param>
        /// <param name="autoModeFactor1"></param>
        /// <param name="autoModeFactor2"></param>
        /// <param name="excitationTimeFactor2"></param>
        /// <param name="excitationTimeFactor3"></param>
        /// <param name="comPolesResistance"></param>
        /// <param name="excitationTimeFactor1"></param>
        /// <param name="maxExcitationTime"></param>
        /// <param name="lowAutoModeRange"></param>
        /// <param name="highAutoModeRange"></param>
        /// <param name="linearGrowCurrentTime"></param>
        /// <param name="connectionPull2"></param>
        public DCMachine(Double disassemblyPowerCircuitTime, Double assemblyBreakTime, Double assemblyPullTime, String trainName, Double assemblyPowerCircuitTime, Double assemblyPullResistance, Double assemblyBreakResistance, Double anchorResistance, Double mainPoleResistance, Double comPolesResistance, Double autoModeFactor1, Double autoModeFactor2, Double excitationTimeFactor1, Double excitationTimeFactor2, Double excitationTimeFactor3, Double maxExcitationTime, Double lowAutoModeRange, Double highAutoModeRange, Double linearGrowCurrentTime, Int32 connectionPull2, Int32 positionPull2, Int32 weakPull2) : base(disassemblyPowerCircuitTime, assemblyBreakTime, assemblyBreakTime, trainName)
        {
            AssemblyPullTime = assemblyPullTime;
            AssemblyPowerCircuitTime = assemblyPowerCircuitTime;
            AssemblyPullResistance = assemblyPullResistance;
            AssemblyBreakResistance = assemblyBreakResistance;
            AnchorResistance = anchorResistance;
            MainPoleResistance = mainPoleResistance;
            ComPolesResistance = comPolesResistance;
            AutoModeFactor1 = autoModeFactor1;
            AutoModeFactor2 = autoModeFactor2;
            ExcitationTimeFactor1 = excitationTimeFactor1;
            ExcitationTimeFactor2 = excitationTimeFactor2;
            ExcitationTimeFactor3 = excitationTimeFactor3;
            MaxExcitationTime = maxExcitationTime;
            LowAutoModeRange = lowAutoModeRange;
            HighAutoModeRange = highAutoModeRange;
            LinearGrowCurrentTime = linearGrowCurrentTime;
            ConnectionPull2 = connectionPull2;
            PositionPull2 = positionPull2;
            WeakPull2 = weakPull2;
        }
    }
}
