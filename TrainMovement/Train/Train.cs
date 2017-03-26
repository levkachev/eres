using System;
using TrainMovement.Machine;
using TrainMovement.ModeControl;
using ORM.Train.Entities;
using TrainMovement.PhisicalHelper;


namespace TrainMovement.Train
{
    /// <summary>
    /// Train
    /// </summary>
    public sealed class Train
    {
        #region Fields
        /// <summary>
        /// Ускорение
        /// </summary>
        private Double acceleration;

        /// <summary>
        /// Ток
        /// </summary>
        private Double current;

        /// <summary>
        /// Масса
        /// </summary>
        private Double mass;

        /// <summary>
        /// Скорость
        /// </summary>
        private Double velocity;

        /// <summary>
        /// Напряжение
        /// </summary>
        private Double voltage;

        /// <summary>
        /// Время
        /// </summary>
        private Double time;

        /// <summary>
        /// Расстояние
        /// </summary>
        private Double space;

        /// <summary>
        /// Параметр двигателя
        /// </summary>
        private BaseMachine Machine;


        /// <summary>
        /// 
        /// </summary>
        private Int32 numberCars;


        /// <summary>
        /// Длина вагона
        /// </summary>
        private Double carLength;

        /// <summary>
        /// Масса порожнего вагона
        /// </summary>
        private Double unladenWeight;
        /// <summary>
        /// 
        /// </summary>
        private Double breakAverage;

        /// <summary>
        /// /
        /// </summary>
        private Double netResistancePullFactor;


        /// <summary>
        /// 
        /// </summary>
        private Double aerodynamicDragFactor;

        /// <summary>
        /// 
        /// </summary>
        private Double netResistanceCoastingFactor1;

        /// <summary>
        /// 
        /// </summary>
        private Double netResistanceCoastingFactor2;

        /// <summary>
        /// 
        /// </summary>
        private Double netResistanceCoastingFactor3;

        /// <summary>
        /// 
        /// </summary>
        private Double trainEquivalentSurface;

        /// <summary>
        /// 
        /// </summary>
        private Double inertiaRotationFactor;

        /// <summary>
        /// 
        /// </summary>
        private Double ownNeedsElectricPower;



        #endregion

        #region Properties

        /// <summary>
        /// Режим ведения
        /// </summary>
        public IModeControl ModeControl { get; set; }

        /// <summary>
        /// Ускорение.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Acceleration
        {
            get
            {
                return acceleration;
            }
            private set
            {
                if (!DomainHelper.CheckAcceleration(value))
                    throw new ArgumentOutOfRangeException(nameof(value));

                acceleration = value;
            }
        }

        /// <summary>
        /// Ток
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Current
        {
            get
            {
                return current;
            }
            set
            {
                if (!DomainHelper.CheckCurrent(value))
                    throw new ArgumentOutOfRangeException(nameof(value));

                current = value;
            }
        }

        /// <summary>
        /// Масса
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Mass
        {
            get
            {
                return mass;
            }
            private set
            {
                if (!DomainHelper.CheckMass(value))
                    throw new ArgumentOutOfRangeException(nameof(value));

                mass = value;
            }
        }

        /// <summary>
        /// Скорость
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Velocity
        {
            get
            {
                return velocity;
            }
            private set
            {
                if (!DomainHelper.CheckVelocity(value))
                    throw new ArgumentOutOfRangeException(nameof(value));

                velocity = value;
            }
        }

        /// <summary>
        /// Напряжение
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Voltage
        {
            get
            {
                return voltage;
            }
            private set
            {
                if (!DomainHelper.CheckVoltage(value))
                    throw new ArgumentOutOfRangeException(nameof(value));

                voltage = value;
            }
        }

        /// <summary>
        /// Расстояние
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Space
        {
            get { return space; }
            set
            {
                if (!DomainHelper.CheckSpace(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                space = value;
            }
        }

        /// <summary>
        /// Время
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Time
        {
            get { return time; }
            set
            {
                if (!DomainHelper.CheckTime(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                time = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL --Длина вагона Lvag
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double CarLength
        {
            get { return carLength; }
            private set
            {
                if (!DomainHelper.CheckCarLength(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                carLength = value;
            }
        }

        /// <summary>
        /// Масса порожнего вагона tara
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double UnladenWeight
        {
            get { return unladenWeight; }
            private set
            {
                if (!DomainHelper.CheckUnladenWeight(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                unladenWeight = value;
            }
        }

        /// <summary>
        /// Количество вагонов nb
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Int32 NumberCars
        {
            get { return numberCars; }
            private set
            {
                if (!DomainHelper.CheckNumberCars(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                numberCars = value;
            }
        }

        /// <summary>
        /// Среднее замедление bsred FLOAT NOT NULL
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double BreakAverage
        {
            get { return breakAverage; }
            private set
            {
                if (!DomainHelper.CheckBreakAverage(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                breakAverage = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL --1-коэффициент основного сопротивления для тяги wwt1
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistancePullFactor
        {
            get { return netResistancePullFactor; }
            private set
            {
                if (!DomainHelper.CheckNetResistancePullFactor(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                netResistancePullFactor = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL -- коэффициент аэродинамического сопротивления wwt2
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double AerodynamicDragFactor
        {
            get { return aerodynamicDragFactor; }
            private set
            {
                if (!DomainHelper.CheckAerodynamicDragFactor(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                aerodynamicDragFactor = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL --1-коэффициент основного сопротивления для выбега wwi1
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistanceCoastingFactor1
        {
            get { return netResistanceCoastingFactor1; }
            private set
            {
                if (!DomainHelper.CheckNetResistanceCoastingFactor1(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                netResistanceCoastingFactor1 = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL --2-коэффициент основного сопротивления для выбега wwi2
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistanceCoastingFactor2
        {
            get { return netResistanceCoastingFactor2; }
            private set
            {
                if (!DomainHelper.CheckNetResistanceCoastingFactor2(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                netResistanceCoastingFactor2 = value;
            }
        }

        /// <summary>
        /// *FLOAT NOT NULL --3-коэффициент основного сопротивления для выбега wwi3
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistanceCoastingFactor3
        {
            get { return netResistanceCoastingFactor3; }
            private set
            {
                if (!DomainHelper.CheckNetResistanceCoastingFactor3(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                netResistanceCoastingFactor3 = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL -- эквивалентная поверхность состава seq
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double TrainEquivalentSurface
        {
            get { return trainEquivalentSurface; }
            private set
            {
                if (!DomainHelper.CheckTrainEquivalentSurface(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                trainEquivalentSurface = value;
            }
        }

        /// <summary>
        /// FLOAT --Коэффициент инерции вращающихся масс gamma0
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double InertiaRotationFactor
        {
            get { return inertiaRotationFactor; }
            private set
            {
                if (!DomainHelper.CheckInertiaRotationFactor(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                inertiaRotationFactor = value;
            }
        }

        /// <summary>
        /// INT NOT NULL--Удельный расход электроэнергии на собственные нужды Eowne
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double OwnNeedsElectricPower
        {
            get { return ownNeedsElectricPower; }
            private set
            {
                if (!DomainHelper.CheckOwnNeedsElectricPower(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                ownNeedsElectricPower = value;
            }
        }


        /// <summary>
        /// Перегон
        /// </summary>
        public Stage.Stage CurrentStage { get; set; }

        /// <summary>
        /// СИла тяги
        /// </summary>
        public Double ForcePull { get; set; }

        /// <summary>
        /// Сила торможения
        /// </summary>
        public Double ForceBreak { get; set; }

        /// <summary>
        /// Сила основного сопротивления
        /// </summary>
        public Double ForceBaseResistance { get; set; }

        /// <summary>
        /// Сила дополнительного сопротивления
        /// </summary>
        public Double ForceAdditionalResistance { get; set; }


        #endregion


        /// <summary>
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="commonProperties"></param>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        internal Train(BaseMachine machine, АdditionalParameter commonProperties)
        {
            CarLength = commonProperties.CarLength;
            UnladenWeight = commonProperties.UnladenWeight;
            NumberCars = commonProperties.NumberCars;
            //Unom = commonProperties.Unom;
            //Umax = commonProperties.Umax;
            //BAverage = commonProperties.BAverage;
            //NetResistencePullFactor = commonProperties.NetResistencePullFactor;
            //AerodynamicDragFactor = commonProperties.AerodynamicDragFactor;
            //NetResistenceCoastingFactor1 = commonProperties.NetResistenceCoastingFactor1;
            //NetResistenceCoastingFactor2 = commonProperties.NetResistenceCoastingFactor2;
            //NetResistenceCoastingFactor3 = commonProperties.NetResistenceCoastingFactor3;
            //TrainEqvivalentSurface = commonProperties.TrainEqvivalentSurface;
            //InertiaRotationFactor = commonProperties.InertiaRotationFactor;
            //AssemblyPowerCircuitTime = commonProperties.AssemblyPowerCircuitTime;
            //DisassemblyPowerCircuitTime = commonProperties.DisassemblyPowerCircuitTime;
            //AssemblyPullTime = commonProperties.AssemblyPullTime;
            //AssemblyPullResistance = commonProperties.AssemblyPullResistance;
            //AssemblyBreakTime = commonProperties.AssemblyBreakTime;
            //AssemblyBreakResistance = commonProperties.AssemblyBreakResistance;
            //AnchorResistance = commonProperties.AnchorResistance;
            //MainPoleResistance = commonProperties.MainPoleResistance;
            //CompolesResistance = commonProperties.CompolesResistance;
            //AutomodeFactor1 = commonProperties.AutomodeFactor1;
            //AutomodeFactor2 = commonProperties.AutomodeFactor2;
            //ExcitationTimeFactor1 = commonProperties.ExcitationTimeFactor1;
            //ExcitationTimeFactor2 = commonProperties.ExcitationTimeFactor2;
            //ExcitationTimeFactor3 =commonProperties.ExcitationTimeFactor3;
            //MaxExcitationTime = commonProperties.MaxExcitationTime;
            //LowAutoModeRange = commonProperties.LowAutoModeRange;
            //HighAutoModeRange = commonProperties.HighAutoModeRange;
            //LinearGrowCurrentTime = commonProperties.LinearGrowCurrentTime;
            //ConnectionPull2 = commonProperties.ConnectionPull2;
            //PositionPull2 = commonProperties.PositionPull2;
            //OwnNeedsElectricPower = commonProperties.OwnNeedsElectricPower;
            //nbAuto = commonProperties.nbAuto;
            //WeakPull2 = commonProperties.WeakPull2;
            Machine = machine;
        }

        /// <summary>
        /// Move by a <paramref name="distance"/> with definite modeControl 
        /// </summary>
        public void Move(Double distance, IModeControl modeControl)
        {
        }

    }
}