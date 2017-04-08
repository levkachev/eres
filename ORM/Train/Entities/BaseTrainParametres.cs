using System;

namespace ORM.Train.Entities
{
    public class BaseTrainParametres
    {
        #region Fields


        private String name;
        /// <summary>
        /// количество вагонов
        /// </summary>
        private Int32 numberCars;


        /// <summary>
        /// Длина вагона
        /// </summary>
        protected Double carLength;

        /// <summary>
        /// Масса порожнего вагона
        /// </summary>
        protected Double unladenWeight;
        /// <summary>
        /// среднее замедление
        /// </summary>
        protected Double breakAverage;

        /// <summary>
        /// 
        /// </summary>
        protected Double netResistancePullFactor;


        /// <summary>
        /// 
        /// </summary>
        protected Double aerodynamicDragFactor;

        /// <summary>
        /// 
        /// </summary>
        protected Double netResistenceCoastingFactor1;

        /// <summary>
        /// 
        /// </summary>
        protected Double netResistenceCoastingFactor2;

        /// <summary>
        /// 
        /// </summary>
        protected Double netResistenceCoastingFactor3;

        /// <summary>
        /// 
        /// </summary>
        protected Double trainEqvivalentSurface;

        /// <summary>
        /// 
        /// </summary>
        protected Double inertiaRotationFactor;

        /// <summary>
        /// 
        /// </summary>
        protected Double ownNeedsElectricPower;



        #endregion

        #region Properties

        public String Name
        {
            get { return name; }
            protected set
            {
                if (value == null)
                    throw new ArgumentNullException(paramName: nameof(value));
                if (value.Trim().Length == 0)
                    throw new ArgumentOutOfRangeException(paramName: nameof(value));
                name = value;
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
                if (value < 0)
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
                if (value < 0)
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
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                numberCars = value;
            }
        }

        /// <summary>
        /// Среднее замедление bsred FLOAT NOT NULL
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double BAverage
        {
            get { return breakAverage; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                breakAverage = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL --1-коэффициент основного сопротивления для тяги wwt1
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistencePullFactor
        {
            get { return netResistancePullFactor; }
            private set
            {
                if (value < 0)
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
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                aerodynamicDragFactor = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL --1-коэффициент основного сопротивления для выбега wwi1
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistenceCoastingFactor1
        {
            get { return netResistenceCoastingFactor1; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                netResistenceCoastingFactor1 = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL --2-коэффициент основного сопротивления для выбега wwi2
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistenceCoastingFactor2
        {
            get { return netResistenceCoastingFactor2; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                netResistenceCoastingFactor2 = value;
            }
        }

        /// <summary>
        /// *FLOAT NOT NULL --3-коэффициент основного сопротивления для выбега wwi3
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double NetResistenceCoastingFactor3
        {
            get { return netResistenceCoastingFactor3; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                netResistenceCoastingFactor3 = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL -- эквивалентная поверхность состава seq
        /// </summary>
        /// /// <exception cref="ArgumentOutOfRangeException" accessor="set"></exception>
        public Double TrainEqvivalentSurface
        {
            get { return trainEqvivalentSurface; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                trainEqvivalentSurface = value;
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
                if (value < 0)
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
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                ownNeedsElectricPower = value;
            }
        }

        #endregion

        public BaseTrainParametres(Int32 numberCars, Double carLength, Double unladenWeight, Double breakAverage, Double netResistancePullFactor, Double aerodynamicDragFactor, Double netResistenceCoastingFactor1, Double netResistenceCoastingFactor2, Double netResistenceCoastingFactor3, Double trainEqvivalentSurface, Double inertiaRotationFactor,Double ownNeedsElectricPower)
        {
            CarLength = carLength;
            UnladenWeight = unladenWeight;
            NumberCars = numberCars;
            BAverage = breakAverage;
            NetResistencePullFactor = netResistancePullFactor;
            AerodynamicDragFactor = aerodynamicDragFactor;
            NetResistenceCoastingFactor1 = netResistenceCoastingFactor1;
            NetResistenceCoastingFactor2 = netResistenceCoastingFactor2;
            NetResistenceCoastingFactor3 = netResistenceCoastingFactor3;
            TrainEqvivalentSurface = trainEqvivalentSurface;
            InertiaRotationFactor = inertiaRotationFactor;
            OwnNeedsElectricPower = ownNeedsElectricPower;
        }

        protected BaseTrainParametres() { }

    }
}
