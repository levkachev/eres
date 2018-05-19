using System;
using Helpers.Physical;

namespace ORM.Trains.Repository.Trains
{
    /// <summary>
    /// Базовые параметры для описания модели электроподвижного состава (ЭПС).
    /// </summary>
    public class BaseTrainParameters
    {
        #region Fields

        /// <summary>
        /// Название модели поезда.
        /// </summary>
        private String name;

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
        /// Коэффициент аэродинамического сопротивления.
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
        /// Эквивалентная поверхность электроподвижного состава (ЭПС).
        /// </summary>
        private Double trainEquivalentSurface;

        /// <summary>
        /// Коэффициент инерции вращающихся масс.
        /// </summary>
        private Double inertiaRotationFactor;

        /// <summary>
        /// Удельный расход электроэнергии на собственные нужды.
        /// </summary>
        private Double ownNeedsElectricPower;

        #endregion

        #region Properties

        /// <summary>
        /// Название модели электроподвижного состава (ЭПС).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
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
        /// Длина вагона, м.
        /// FLOAT NOT NULL --Длина вагона Lvag
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double CarLength
        {
            get => carLength;
            protected set
            {
                if (!TrainHelper.CheckCarLength(value))
                    throw new ArgumentOutOfRangeException(nameof(CarLength));
                carLength = value;
            }
        }

        /// <summary>
        /// Масса порожнего вагона, т.
        /// tara
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double UnladenWeight
        {
            get => unladenWeight;
            protected set
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
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Int32 NumberCars
        {
            get => numberCars;
            protected set
            {
                if (!TrainHelper.CheckNumberCars(value))
                    throw new ArgumentOutOfRangeException(nameof(NumberCars));
                numberCars = value;
            }
        }

        /// <summary>
        /// Среднее замедление, м/c^2.
        /// bsred FLOAT NOT NULL
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double BreakAverage
        {
            get => breakAverage;
            protected set
            {
                if (!TrainHelper.CheckBreakAverage(value))
                    throw new ArgumentOutOfRangeException(nameof(BreakAverage));
                breakAverage = value;
            }
        }

        /// <summary>
        /// Коэффициент основного сопротивления для тяги.
        /// FLOAT NOT NULL --1-коэффициент основного сопротивления для тяги wwt1
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistancePullFactor
        {
            get => netResistancePullFactor;
            protected set
            {
                if (!TrainHelper.CheckNetResistancePullFactor(value))
                    throw new ArgumentOutOfRangeException(nameof(NetResistancePullFactor));
                netResistancePullFactor = value;
            }
        }

        /// <summary>
        /// Коэффициент аэродинамического сопротивления.
        /// FLOAT NOT NULL -- коэффициент аэродинамического сопротивления wwt2
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double AerodynamicDragFactor
        {
            get => aerodynamicDragFactor;
            protected set
            {
                if (!TrainHelper.CheckAerodynamicDragFactor(value))
                    throw new ArgumentOutOfRangeException(nameof(AerodynamicDragFactor));
                aerodynamicDragFactor = value;
            }
        }

        /// <summary>
        /// Первый коэффициент основного сопротивления для выбега.
        /// FLOAT NOT NULL --1-коэффициент основного сопротивления для выбега wwi1
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistanceCoastingFactor1
        {
            get => netResistanceCoastingFactor1;
            protected set
            {
                if (!TrainHelper.CheckNetResistanceCoastingFactor1(value))
                    throw new ArgumentOutOfRangeException(nameof(NetResistanceCoastingFactor1));
                netResistanceCoastingFactor1 = value;
            }
        }

        /// <summary>
        /// Второй коэффициент основного сопротивления для выбега.
        /// FLOAT NOT NULL --2-коэффициент основного сопротивления для выбега wwi2
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistanceCoastingFactor2
        {
            get => netResistanceCoastingFactor2;
            protected set
            {
                if (!TrainHelper.CheckNetResistanceCoastingFactor2(value))
                    throw new ArgumentOutOfRangeException(nameof(NetResistanceCoastingFactor2));
                netResistanceCoastingFactor2 = value;
            }
        }

        /// <summary>
        /// Третий коэффициент основного сопротивления для выбега.
        /// *FLOAT NOT NULL --3-коэффициент основного сопротивления для выбега wwi3
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistanceCoastingFactor3
        {
            get => netResistanceCoastingFactor3;
            protected set
            {
                if (!TrainHelper.CheckNetResistanceCoastingFactor3(value))
                    throw new ArgumentOutOfRangeException(nameof(NetResistanceCoastingFactor3));
                netResistanceCoastingFactor3 = value;
            }
        }

        /// <summary>
        /// Эквивалентная поверхность электроподвижного состава (ЭПС).
        /// FLOAT NOT NULL -- эквивалентная поверхность состава seq
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double TrainEquivalentSurface
        {
            get => trainEquivalentSurface;
            protected set
            {
                if (!TrainHelper.CheckTrainEquivalentSurface(value))
                    throw new ArgumentOutOfRangeException(nameof(TrainEquivalentSurface));
                trainEquivalentSurface = value;
            }
        }

        /// <summary>
        /// Коэффициент инерции вращающихся масс.
        /// FLOAT --Коэффициент инерции вращающихся масс gamma0
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double InertiaRotationFactor
        {
            get => inertiaRotationFactor;
            protected set
            {
                if (!TrainHelper.CheckInertiaRotationFactor(value))
                    throw new ArgumentOutOfRangeException(nameof(InertiaRotationFactor));
                inertiaRotationFactor = value;
            }
        }

        /// <summary>
        /// Удельный расход электроэнергии на собственные нужды.
        /// INT NOT NULL--Удельный расход электроэнергии на собственные нужды Eowne
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double OwnNeedsElectricPower
        {
            get => ownNeedsElectricPower;
            protected set
            {
                if (!TrainHelper.CheckOwnNeedsElectricPower(value))
                    throw new ArgumentOutOfRangeException(nameof(OwnNeedsElectricPower));
                ownNeedsElectricPower = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        protected BaseTrainParameters() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberCars">Число вагонов, шт.</param>
        /// <param name="carLength">Длина вагона, м.</param>
        /// <param name="unladenWeight">Масса порожнего вагона, т.</param>
        /// <param name="breakAverage">Среднее замедление, м/с^2.</param>
        /// <param name="netResistancePullFactor"></param>
        /// <param name="aerodynamicDragFactor">Коэффициент аэродинамического сопротивления.</param>
        /// <param name="netResistanceCoastingFactor1">Первый коэффициент основного сопротивления для выбега.</param>
        /// <param name="netResistanceCoastingFactor2">Второй коэффициент основного сопротивления для выбега.</param>
        /// <param name="netResistanceCoastingFactor3">Третий коэффициент основного сопротивления для выбега.</param>
        /// <param name="trainEquivalentSurface">Эквивалентная поверхность электроподвижного состава (ЭПС).</param>
        /// <param name="inertiaRotationFactor">Коэффициент инерции вращающихся масс.</param>
        /// <param name="ownNeedsElectricPower">Удельный расход электроэнергии на собственные нужды.</param>
        /// <param name="name">Название модели электроподвижного состава (ЭПС).</param>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        internal BaseTrainParameters(Int32 numberCars, Double carLength, Double unladenWeight, Double breakAverage, Double netResistancePullFactor, Double aerodynamicDragFactor, Double netResistanceCoastingFactor1, Double netResistanceCoastingFactor2, Double netResistanceCoastingFactor3, Double trainEquivalentSurface, Double inertiaRotationFactor, Double ownNeedsElectricPower, String name)
        {
            CarLength = carLength;
            UnladenWeight = unladenWeight;
            NumberCars = numberCars;
            BreakAverage = breakAverage;
            NetResistancePullFactor = netResistancePullFactor;
            AerodynamicDragFactor = aerodynamicDragFactor;
            NetResistanceCoastingFactor1 = netResistanceCoastingFactor1;
            NetResistanceCoastingFactor2 = netResistanceCoastingFactor2;
            NetResistanceCoastingFactor3 = netResistanceCoastingFactor3;
            TrainEquivalentSurface = trainEquivalentSurface;
            InertiaRotationFactor = inertiaRotationFactor;
            OwnNeedsElectricPower = ownNeedsElectricPower;
            Name = name;
        }

        /// <inheritdoc />
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters">Параметры электроподвижного состава (ЭПС).</param>
        internal BaseTrainParameters(BaseTrainParameters parameters) : this(parameters.NumberCars, parameters.CarLength, parameters.UnladenWeight, parameters.BreakAverage, parameters.NetResistancePullFactor, parameters.AerodynamicDragFactor, parameters.NetResistanceCoastingFactor1, parameters.NetResistanceCoastingFactor2, parameters.NetResistanceCoastingFactor3, parameters.TrainEquivalentSurface, parameters.InertiaRotationFactor, parameters.OwnNeedsElectricPower, parameters.Name) { }

        #endregion
    }
}
