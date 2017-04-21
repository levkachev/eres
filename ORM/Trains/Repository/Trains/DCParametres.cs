using System;

namespace ORM.Trains.Repository.Trains
{
    /// <summary>
    /// 
    /// </summary>
   public class DCParametres : BaseTrainParametres
    {
        /// <summary>
        /// 
        /// </summary>
        private Double assemblyPowerCircuitTime;

        /// <summary>
        /// 
        /// </summary>
        private Double disassemblyPowerCircuitTime;

        /// <summary>
        /// 
        /// </summary>
        private Double assemblyPullTime;

        /// <summary>
        /// 
        /// </summary>
        private Double assemblyPullResistance;

        /// <summary>
        /// 
        /// </summary>
        private Double assemblyBreakTime;

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
        private Double excitationTime;

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

        #region Properties

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double AssemblyPowerCircuitTime
        {
            get { return assemblyPowerCircuitTime; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                assemblyPowerCircuitTime = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double DisassemblyPowerCircuitTime
        {
            get { return disassemblyPowerCircuitTime; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                disassemblyPowerCircuitTime = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double AssemblyPullTime
        {
            get { return assemblyPullTime; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                assemblyPullTime = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double AssemblyPullResistance
        {
            get { return assemblyPullResistance; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                assemblyPullResistance = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double AssemblyBreakTime
        {
            get { return assemblyBreakTime; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                assemblyBreakTime = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double AssemblyBreakResistance
        {
            get { return assemblyBreakResistance; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                assemblyBreakResistance = value;
            }
        }

        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double AnchorResistance
        {
            get { return anchorResistance; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                anchorResistance = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double MainPoleResistance
        {
            get { return mainPoleResistance; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                mainPoleResistance = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Double ComPolesResistance
        {
            get { return comPolesResistance; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                comPolesResistance = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Double AutoModeFactor1
        {
            get { return autoModeFactor1; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                autoModeFactor1 = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double AutoModeFactor2
        {
            get { return autoModeFactor2; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                autoModeFactor2 = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double ExcitationTimeFactor1
        {
            get { return excitationTimeFactor1; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                excitationTimeFactor1 = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double ExcitationTimeFactor2
        {
            get { return excitationTimeFactor2; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                excitationTimeFactor2 = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double ExcitationTimeFactor3
        {
            get { return excitationTimeFactor3; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                excitationTimeFactor3 = value;
            }
        }

        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double MaxExcitationTime
        {
            get { return excitationTime; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                excitationTime = value;
            }
        }

        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double LowAutoModeRange
        {
            get { return lowAutoModeRange; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                lowAutoModeRange = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double HighAutoModeRange
        {
            get { return highAutoModeRange; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                highAutoModeRange = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double LinearGrowCurrentTime
        {
            get { return linearGrowCurrentTime; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                linearGrowCurrentTime = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
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
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Int32 PositionPull2
        {
            get { return positionPull2; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                positionPull2 = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Int32 WeakPull2
        {
            get { return weakPull2; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                weakPull2 = value;
            }
        }

        #endregion


        public DCParametres(Int32 numberCars, Double carLength, Double unladenWeight, Double breakAverage,
            Double netResistancePullFactor, Double aerodynamicDragFactor, Double netResistenceCoastingFactor1,
            Double netResistenceCoastingFactor2, Double netResistenceCoastingFactor3, Double trainEqvivalentSurface,
            Double inertiaRotationFactor, Double ownNeedsElectricPower, Double assemblyPowerCircuitTime, Double disassemblyPowerCircuitTime, Double assemblyPullTime, Double assemblyPullResistance, Double autoModeFactor1, Double lowAutoModeRange, Double highAutoModeRange, Double linearGrowCurrentTime, Int32 connectionPull2, Int32 positionPull2, Int32 weakPull2)
            : base(
                numberCars, carLength, unladenWeight, breakAverage, netResistancePullFactor, aerodynamicDragFactor,
                netResistenceCoastingFactor1, netResistenceCoastingFactor2, netResistenceCoastingFactor3,
                trainEqvivalentSurface, inertiaRotationFactor, ownNeedsElectricPower)
        {
            AssemblyPowerCircuitTime = assemblyPowerCircuitTime;
            DisassemblyPowerCircuitTime = disassemblyPowerCircuitTime;
            AssemblyPullTime = assemblyPullTime;
            AssemblyPullResistance = assemblyPullResistance;
            AutoModeFactor1 = autoModeFactor1;
            LowAutoModeRange = lowAutoModeRange;
            HighAutoModeRange = highAutoModeRange;
            LinearGrowCurrentTime = linearGrowCurrentTime;
            ConnectionPull2 = connectionPull2;
            PositionPull2 = positionPull2;
            WeakPull2 = weakPull2;
        }
    }

}