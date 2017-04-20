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
        private Double eaxExcitationTime;
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
        private Int32wWeakPull2;

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


        public Double compolesResistance
        {
            get { return CompolesResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                CompolesResistance = value;
            }
        }

        public Double automodeFactor1
        {
            get { return AutomodeFactor1; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                AutomodeFactor1 = value;
            }
        }

        public Double automodeFactor2
        {
            get { return AutomodeFactor2; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                AutomodeFactor2 = value;
            }
        }


        public Double excitationTimeFactor1
        {
            get { return ExcitationTimeFactor1; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                ExcitationTimeFactor1 = value;
            }
        }

        public Double excitationTimeFactor2
        {
            get { return ExcitationTimeFactor2; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                ExcitationTimeFactor2 = value;
            }
        }

        public Double excitationTimeFactor3
        {
            get { return ExcitationTimeFactor3; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                ExcitationTimeFactor3 = value;
            }
        }

        public Double maxExcitationTime
        {
            get { return MaxExcitationTime; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                MaxExcitationTime = value;
            }
        }

        public Double lowAutoModeRange
        {
            get { return LowAutoModeRange; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                LowAutoModeRange = value;
            }
        }

        public Double highAutoModeRange
        {
            get { return HighAutoModeRange; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                HighAutoModeRange = value;
            }
        }

        public Double linearGrowCurrentTime
        {
            get { return LinearGrowCurrentTime; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                LinearGrowCurrentTime = value;
            }
        }

        public Int32 connectionPull2;
        public Int32 positionPull2;
        public Int32 weakPull2;
        #endregion

    }

}