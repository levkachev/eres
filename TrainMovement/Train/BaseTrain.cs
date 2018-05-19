using System;
using System.Collections.Generic;

using ORM.Trains.Entities;
using ORM.Trains.Repository;
using ORM.Trains.Repository.Machine;
using ORM.Trains.Repository.Trains;

using TrainMovement.ModeControl;

using Helpers.Math;
using Helpers.Physical;

namespace TrainMovement.Train
{
    /// <summary>
    /// Модель электроподвижного состава (ЭПС).
    /// </summary>
    public abstract class BaseTrain
    {
        #region Constants

        /// <summary>
        /// Приращение силы, 
        /// </summary>
        private const Double dF = 7.2;

        /// <summary>
        /// Приращение тока, А.
        /// </summary>
        private const Double dIc = 850;

        /// <summary>
        /// Номинальное значение напряжения, В.
        /// </summary>
        private const Double voltageNominal = 750;

        /// <summary>
        /// Количество моторов в вагоне поезда, шт.
        /// </summary>
        private const Int16 motorCount = 4;

        /// <summary>
        /// Минимальное (для апроксимации) значение скорости в километрах в час [?] ("чтобы понять, что уже поехали").
        /// </summary>
        private const Double minimalVelocity = 0.1;

        /// <summary>
        /// Минимальное (для апроксимации) значение времени в секундах ("чтобы понять, что уже поехали").
        /// </summary>
        private const Double minimalTime = 1;

        /// <summary>
        /// Максимальная (для апроксимации) масса загруженности вагона в тоннах.
        /// </summary>
        private const Double maximalMassForCarInTonas = 20;

        #endregion

        #region Fields

        /// <summary>
        /// Мелешин 2016
        /// </summary>
        private Double kF;

        /// <summary>
        /// расход энергии
        /// </summary>
        private Double a;

        /// <summary>
        /// 
        /// </summary>
        private Double ForceKGC;

        /// <summary>
        /// 
        /// </summary>
        private Double Ip;

        /// <summary>
        /// Время хода в текщем режиме, с.
        /// </summary>
        private Double tPos;

        /// <summary>
        /// Коэффициент перевода инерции вращающихся масс и массы поезда в СИ.
        /// </summary>
        private Double factor;

        /// <summary>
        /// Ускорение, м/с^2.
        /// </summary>
        private Double acceleration;

        /// <summary>
        /// Название модели подвижного состава.
        /// </summary>
        private String name;

        /// <summary>
        /// Ток, А.
        /// </summary>
        private Double current;

        /// <summary>
        /// Масса людей в вагоне, т.
        /// </summary>
        private Double mass;

        /// <summary>
        /// Скорость, .
        /// </summary>
        private Double velocity;

        /// <summary>
        /// Напряжение, В.
        /// </summary>
        private Double voltage;

        /// <summary>
        /// Время, с.
        /// </summary>
        private Double time;

        /// <summary>
        /// Расстояние, пройденное от начала перегона, в метрах.
        /// </summary>
        private Double space;

        /// <summary>
        /// Тип двигателя.
        /// </summary>
        private BaseMachine machine;

        /// <summary>
        /// Количество вагонов, шт.
        /// </summary>
        private Int32 numberCars;

        /// <summary>
        /// Длина вагона, м.
        /// </summary>
        private Double carLength;

        /// <summary>
        /// Масса порожнего вагона, т.
        /// </summary>
        private Double unladenWeight;

        /// <summary>
        /// Среднее замедление, м/с^2.
        /// </summary>
        private Double breakAverage;

        /// <summary>
        /// Коэффициент основного сопротивления для тяги.
        /// </summary>
        private Double netResistancePullFactor;

        /// <summary>
        /// Коэффициент аэродинамического сопротивления.
        /// </summary>
        private Double aerodynamicDragFactor;

        /// <summary>
        /// Первый коэффициент основного сопротивления для выбега.
        /// </summary>
        private Double netResistanceCoastingFactor1;

        /// <summary>
        /// Второй коэффициент основного сопротивления для выбега.
        /// </summary>
        private Double netResistanceCoastingFactor2;

        /// <summary>
        /// Третий коэффициент основного сопротивления для выбега.
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

        /// <summary>
        /// 
        /// </summary>
        private Guid currentStage;

        /// <summary>
        /// 
        /// </summary>
        private EventBroker broker;

        /// <summary>
        /// Текущий режим ведения.
        /// </summary>
        private IModeControl currentModeControl;


        #endregion

        #region Properties
        /// <summary>
        /// Двигатель
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        public BaseMachine Machine
        {
            get => machine;
            set => machine = value ?? throw new ArgumentNullException(nameof(Machine));
        }

        /// <summary>
        /// Координата поезда на линии
        /// </summary>
        public Double SpacePiketage { get; set; }

        /// <summary>
        /// Текущий режим ведения.
        /// </summary>
        public IModeControl CurrentModeControl
        {
            get => currentModeControl;
            set => currentModeControl = value ?? throw new ArgumentNullException(nameof(CurrentModeControl));
        } 

        /// <summary>
        /// Ускорение, м/с^2.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Acceleration
        {
            get => acceleration;
            private set
            {
                if (!TrainHelper.CheckAcceleration(value))
                    throw new ArgumentOutOfRangeException(nameof(Acceleration));

                acceleration = value;
            }
        }

        /// <summary>
        /// Ток, А.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Current
        {
            get => current;
            set
            {
                if (!TrainHelper.CheckCurrent(value))
                    throw new ArgumentOutOfRangeException(nameof(Current));

                current = value;
            }
        }

        /// <summary>
        /// Масса, т.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Mass
        {
            get => mass;
            private set
            {
                if (!TrainHelper.CheckMass(value))
                    throw new ArgumentOutOfRangeException(nameof(Mass));

                mass = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Mass byMass;

        /// <summary>
        /// 
        /// </summary>
        public Mass ByMass
        {
            get => byMass;
            set => byMass = value ?? throw new ArgumentNullException(nameof(ByMass));
        }

        /// <summary>
        /// Скорость, км/ч.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Velocity
        {
            get => velocity;
            protected set
            {
                if (!TrainHelper.CheckVelocity(value))
                    throw new ArgumentOutOfRangeException(nameof(Velocity));
                
                velocity = value.ToNonNegativeValue();
            }
        }

        /// <summary>
        /// Напряжение, В.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Voltage
        {
            get => voltage;
            set
            {
                if (!TrainHelper.CheckVoltage(value))
                    throw new ArgumentOutOfRangeException(nameof(Voltage));

                voltage = value;
            }
        }

        /// <summary>
        /// Расстояние, м.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException" accessor="set">Представленный делегатом метод является методом экземпляра, а целевой объект имеет значение null.-или- Один из инкапсулированных методов выбрасывает исключение. </exception>
        public Double Space
        {
            get => space;
            set
            {
                if (!TrainHelper.CheckSpace(value))
                    throw new ArgumentOutOfRangeException(nameof(Space));

                if (value.IsEqual(space) && !value.IsZero())
                    return;
                
                space = value;
                SpaceChanged();
            }
        }

        /// <summary>
        /// Время, с.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double Time
        {
            get => time;
            set
            {
                if (!TrainHelper.CheckTime(value))
                    throw new ArgumentOutOfRangeException(nameof(Time));

                time = value;
            }
        }

        /// <summary>
        /// Брокер событий.
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        protected EventBroker Broker
        {
            get => broker;
            set => broker = value ?? throw new ArgumentNullException(nameof(Broker));
        }

        /// <summary>
        /// Длина вагона, м.
        /// FLOAT NOT NULL --Длина вагона Lvag
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double CarLength
        {
            get => carLength;
            private set
            {
                if (!TrainHelper.CheckCarLength(value))
                    throw new ArgumentOutOfRangeException(nameof(CarLength));
                carLength = value;
            }
        }

        /// <summary>
        /// Масса порожнего вагона, т.
        /// (tara)
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"/>
        public Double UnladenWeight
        {
            get => unladenWeight;
            private set
            {
                if (!TrainHelper.CheckUnladenWeight(value))
                    throw new ArgumentOutOfRangeException(nameof(UnladenWeight));

                unladenWeight = value;
            }
        }

        /// <summary>
        /// Количество вагонов, шт.
        /// nb
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"/>
        public Int32 NumberCars
        {
            get => numberCars;
            private set
            {
                if (!TrainHelper.CheckNumberCars(value))
                    throw new ArgumentOutOfRangeException(nameof(NumberCars));

                numberCars = value;
            }
        }

        /// <summary>
        /// Среднее замедление, м/с^2
        /// bsred FLOAT NOT NULL
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double BreakAverage
        {
            get => breakAverage;
            private set
            {
                if (!TrainHelper.CheckBreakAverage(value))
                    throw new ArgumentOutOfRangeException(nameof(BreakAverage));
                breakAverage = value;
            }
        }

        /// <summary>
        /// Коэффициент основного сопротивления для тяги
        /// FLOAT NOT NULL --1-коэффициент основного сопротивления для тяги wwt1
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistancePullFactor
        {
            get => netResistancePullFactor;
            private set
            {
                if (!TrainHelper.CheckNetResistancePullFactor(value))
                    throw new ArgumentOutOfRangeException(nameof(NetResistancePullFactor));
                netResistancePullFactor = value;
            }
        }

        /// <summary>
        /// Коэффициент аэродинамического сопротивления
        /// FLOAT NOT NULL -- коэффициент аэродинамического сопротивления wwt2
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double AerodynamicDragFactor
        {
            get => aerodynamicDragFactor;
            private set
            {
                if (!TrainHelper.CheckAerodynamicDragFactor(value))
                    throw new ArgumentOutOfRangeException(nameof(AerodynamicDragFactor));
                aerodynamicDragFactor = value;
            }
        }

        /// <summary>
        /// Первый коэффициент основного сопротивления для выбега
        /// FLOAT NOT NULL --1-коэффициент основного сопротивления для выбега wwi1
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistanceCoastingFactor1
        {
            get => netResistanceCoastingFactor1;
            private set
            {
                if (!TrainHelper.CheckNetResistanceCoastingFactor1(value))
                    throw new ArgumentOutOfRangeException(nameof(NetResistanceCoastingFactor1));
                netResistanceCoastingFactor1 = value;
            }
        }

        /// <summary>
        /// Второй коэффициент основного сопротивления для выбега
        /// FLOAT NOT NULL --2-коэффициент основного сопротивления для выбега wwi2
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistanceCoastingFactor2
        {
            get => netResistanceCoastingFactor2;
            private set
            {
                if (!TrainHelper.CheckNetResistanceCoastingFactor2(value))
                    throw new ArgumentOutOfRangeException(nameof(NetResistanceCoastingFactor2));
                netResistanceCoastingFactor2 = value;
            }
        }

        /// <summary>
        /// Третий коэффициент основного сопротивления для выбега
        ///  *FLOAT NOT NULL --3-коэффициент основного сопротивления для выбега wwi3
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistanceCoastingFactor3
        {
            get => netResistanceCoastingFactor3;
            private set
            {
                if (!TrainHelper.CheckNetResistanceCoastingFactor3(value))
                    throw new ArgumentOutOfRangeException(nameof(NetResistanceCoastingFactor3));
                netResistanceCoastingFactor3 = value;
            }
        }

        /// <summary>
        /// Эквивалентная поверхность состава
        /// FLOAT NOT NULL -- эквивалентная поверхность состава seq
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double TrainEquivalentSurface
        {
            get => trainEquivalentSurface;
            private set
            {
                if (!TrainHelper.CheckTrainEquivalentSurface(value))
                    throw new ArgumentOutOfRangeException(nameof(TrainEquivalentSurface));
                trainEquivalentSurface = value;
            }
        }

        /// <summary>
        /// Коэффициент инерции вращающихся масс
        /// FLOAT --Коэффициент инерции вращающихся масс gamma0
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double InertiaRotationFactor
        {
            get => inertiaRotationFactor;
            private set
            {
                if (!TrainHelper.CheckInertiaRotationFactor(value))
                    throw new ArgumentOutOfRangeException(nameof(InertiaRotationFactor));
                inertiaRotationFactor = value;
            }
        }

        /// <summary>
        /// INT NOT NULL--Удельный расход электроэнергии на собственные нужды Eowne
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double OwnNeedsElectricPower
        {
            get => ownNeedsElectricPower;
            private set
            {
                if (!TrainHelper.CheckOwnNeedsElectricPower(value))
                    throw new ArgumentOutOfRangeException(nameof(OwnNeedsElectricPower));
                ownNeedsElectricPower = value;
            }
        }

        /// <summary>
        /// Название типа элекроподвижного состава (ЭПС)
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">empty.</exception>
        public String Name
        {
            get => name;
            protected set
            {
                if (!TrainHelper.CheckName(value))
                    throw new ArgumentOutOfRangeException(nameof(Name));
                name = value;
            }
        }

        /// <summary>
        /// Перегон
        /// </summary>
        public Guid CurrentStage
        {
            get => currentStage;
            private set => currentStage = value;
        }

        /// <summary>
        /// Сила тяги или торможения
        /// </summary>
        public Double Force { get; set; }

        /// <summary>
        /// Сила основного сопротивления
        /// </summary>
        public Double ForceBaseResistance { get; set; }

        /// <summary>
        /// Сила дополнительного сопротивления
        /// </summary>
        public Double ForceAdditionalResistance { get; set; }

        /// <summary>
        /// Коэффициент открытых участков
        /// </summary>
        public Double FactorOfOpenStage { get; set; }

        /// <summary>
        /// Возможность ехать в тяге
        /// </summary>
        public Boolean CanPullOrBreak { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Double MaxVelocity { get; set; }

        /// <summary>
        /// Время хода в текщем режиме, с.
        /// </summary>
        public Double TimeInModeControl
        {
            get => tPos;
            private set
            {
                if (!value.IsIntoRange(0, Time))
                    throw new ArgumentOutOfRangeException(nameof(TimeInModeControl));
                tPos = value;
            }
        }

        /// <summary>
        /// Расход энергии
        /// </summary>
        public Double A
        {
            get => a;
            set
            {
                if (!TrainHelper.CheckEnergyConsumption(value))
                    throw new ArgumentOutOfRangeException(nameof(A));
                a = value;
            }
        }

        public ISet<IModeControl> ModeControls { get; set; } = new SortedSet<IModeControl>();

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="commonProperties"></param>
        /// <param name="broker"></param>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        protected BaseTrain(BaseMachine machine, BaseTrainParameters commonProperties, EventBroker broker)
        {
            CarLength = commonProperties.CarLength;
            UnladenWeight = commonProperties.UnladenWeight;
            NumberCars = commonProperties.NumberCars;
            BreakAverage = commonProperties.BreakAverage;
            NetResistancePullFactor = commonProperties.NetResistancePullFactor;
            AerodynamicDragFactor = commonProperties.AerodynamicDragFactor;
            NetResistanceCoastingFactor1 = commonProperties.NetResistanceCoastingFactor1;
            NetResistanceCoastingFactor2 = commonProperties.NetResistanceCoastingFactor2;
            NetResistanceCoastingFactor3 = commonProperties.NetResistanceCoastingFactor3;
            TrainEquivalentSurface = commonProperties.TrainEquivalentSurface;
            InertiaRotationFactor = commonProperties.InertiaRotationFactor;
            OwnNeedsElectricPower = commonProperties.OwnNeedsElectricPower;

            Machine = machine;
            Broker = broker;    
        }

        /// <summary>
        /// Изменение кординаты поезда на перегоне приводит к событию
        /// </summary>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        /// <exception cref="MemberAccessException">Вызывающий код не имеет доступа к методу, представленному делегатом (например, если это закрытый метод).-или- Количество, порядок или тип параметров в списке <paramref name="args" /> является недопустимым. </exception>
        /// <exception cref="System.Reflection.TargetInvocationException">Представленный делегатом метод является методом экземпляра, а целевой объект имеет значение null.-или- Один из инкапсулированных методов выбрасывает исключение. </exception>
        public void SpaceChanged() => Broker.Publish(this, new EventArgs());

        /// <summary>
        /// 
        /// </summary>
        protected BaseTrain() { }

        /// <summary>
        /// Move by a <paramref name="distance"/> with definite modeControl 
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<OutTrainParameters> Move(Double distance, IModeControl modeControl, Double massForInterpolation, Double stepOfIntegration)
        {
            var result = new List<OutTrainParameters>();
            CurrentModeControl = modeControl;

            ByMass = MassRepository.GetInstance().GetByMass(massForInterpolation);

            while (IsAlreadyMoving(distance, stepOfIntegration))
            {
                if (Velocity >= MaxVelocity && CurrentModeControl is IPull)
                {
                    CurrentModeControl = CurrentModeControl.Low(ByMass);
                    TimeInModeControl = 0;
                }

                if (!CanPullOrBreak && (CurrentModeControl is IPull || CurrentModeControl is IRecuperationBreak))
                {
                    CurrentModeControl = CurrentModeControl is IPull 
                        ? CurrentModeControl.Low(ByMass) 
                        : CurrentModeControl.High(ByMass);
                    TimeInModeControl = 0;
                }

                Step(stepOfIntegration, distance);
                var step = new OutTrainParameters(CurrentModeControl, Current, Space, Time, SpacePiketage, Velocity, ForceAdditionalResistance, ForceBaseResistance, Force);
                result.Add(step);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="stepOfIntegration"></param>
        /// <returns></returns>
        private Boolean IsAlreadyMoving(Double distance, Double stepOfIntegration) => 
            distance - Space > Converter.GetVelocityMeterPerSec(Velocity) * stepOfIntegration 
            && Time > minimalTime 
            && Velocity > minimalVelocity 
            || Time <= minimalTime;

        /// <summary>
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Condition.</exception>
        /// <exception cref="System.Reflection.TargetInvocationException">Представленный делегатом метод является методом экземпляра, а целевой объект имеет значение null.-или- Один из инкапсулированных методов выбрасывает исключение. </exception>
        public void Start(Guid stage, Double mass)
        {
            CurrentStage = stage;
            Velocity = 0.0;
            Space = 0.0;
            Mass = mass;
            factor = Converter.GetFactor() / ( 1 + InertiaRotationFactor * UnladenWeight / (UnladenWeight + Mass));
            kF = Mass < maximalMassForCarInTonas ? 1 + Mass / UnladenWeight * 0.93 : 1 + maximalMassForCarInTonas / UnladenWeight;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void Step(Double stepOfIntegration, Double distance)
        {
            var lastForce = ForceKGC;
            var lastCurrent = Ip;

            Current = CurrentModeControl.GetCurrent(Velocity, this);
            if (Voltage > 750)
                Current = Current * voltageNominal / Voltage;

            ForceKGC = CurrentModeControl.GetForce(Velocity, this);
            if (Math.Abs(ForceKGC - lastForce) > stepOfIntegration * dF)
                ForceKGC = lastForce + Math.Sign(ForceKGC - lastForce) * stepOfIntegration * dF;

            if (Math.Abs(Math.Abs(Current) - Math.Abs(lastCurrent)) > dIc * stepOfIntegration)
                Current = lastCurrent + Math.Sign(Current - lastCurrent) * dIc * stepOfIntegration;

            Ip = Current;
            
            var dA = Voltage*Current;
            var dAeown = Converter.GetInKilo(OwnNeedsElectricPower)*stepOfIntegration;
            A += dAeown;
            Current = Current + dAeown/Voltage;
            Current *= NumberCars;
            Force = Converter.GetForceInKNewton(ForceKGC) * motorCount / (UnladenWeight + Mass);
       
            ForceBaseResistance = CurrentModeControl.GetBaseResistance(this);
            var acc = Force - ForceAdditionalResistance - ForceBaseResistance;
            var dV = factor * stepOfIntegration * acc;
            if (CurrentModeControl is IBreak)
            {
                Current *= -1 * 2.5 * kF;
                Force *= -1;
                dV = -BreakAverage*stepOfIntegration*3.6;
            }

            if (CurrentModeControl is IAverageBreak)
                Acceleration = BreakAverage;
            else
                Acceleration = Converter.GetVelocityMeterPerSec(dV) / stepOfIntegration;

            Velocity += dV;
            Time += stepOfIntegration;
            TimeInModeControl += stepOfIntegration;

            A += dA * stepOfIntegration;

            if (Velocity >= MaxVelocity && CurrentModeControl is IInert && dV > 0)
            {
                CurrentModeControl = CurrentModeControl.Low(ByMass);
                TimeInModeControl = 0;
            }

            var dS = Converter.GetVelocityMeterPerSec(Velocity) * stepOfIntegration;
            if (distance - space >= dS)
                Space += dS;
        }
    }
}