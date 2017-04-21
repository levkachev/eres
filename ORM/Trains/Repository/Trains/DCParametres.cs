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
        private Double compolesResistance;
        /// <summary>
        /// 
        /// </summary>
        private Double automodeFactor1;
        /// <summary>
        /// 
        /// </summary>
        private Double automodeFactor2;
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

        #region Properties

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
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
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double DisassemblyPowerCircuitTime
        {
            get { return disassemblyPowerCircuitTime; }
            set
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
            set
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
            set
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
            set
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
            set
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
            set
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
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                mainPoleResistance = value;
            }
        }


        public Double CompolesResistance
        {
            get { return compolesResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                compolesResistance = value;
            }
        }

        public Double AutomodeFactor1
        {
            get { return automodeFactor1; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                automodeFactor1 = value;
            }
        }

        public Double AutomodeFactor2
        {
            get { return automodeFactor2; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                automodeFactor2 = value;
            }
        }


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

        public Int32 ConnectionPull2;
        public Int32 PositionPull2;
        public Int32 WeakPull2;
        #endregion

    }

}