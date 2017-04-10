using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Train.Entities
{
   public class DCParametres : BaseTrainParametres
    {
        private Double AssemblyPowerCircuitTime;
        private Double DisassemblyPowerCircuitTime;
        private Double AssemblyPullTime;
        private Double AssemblyPullResistance;
        private Double AssemblyBreakTime;
        private Double AssemblyBreakResistance;
        private Double AnchorResistance;
        private Double MainPoleResistance;
        private Double CompolesResistance;
        private Double AutomodeFactor1;
        private Double AutomodeFactor2;
        private Double ExcitationTimeFactor1;
        private Double ExcitationTimeFactor2;
        private Double ExcitationTimeFactor3;
        private Double MaxExcitationTime;
        private Double LowAutoModeRange;
        private Double HighAutoModeRange;
        private Double LinearGrowCurrentTime;
        private Int32 ConnectionPull2;
        private Int32 PositionPull2;
        private Int32 WeakPull2;

        #region Properties
        public Double assemblyPowerCircuitTime
        {
            get { return AssemblyPowerCircuitTime; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                AssemblyPowerCircuitTime = value;
            }
        }

        public Double disassemblyPowerCircuitTime
        {
            get { return DisassemblyPowerCircuitTime; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                DisassemblyPowerCircuitTime = value;
            }
        }
        public Double assemblyPullTime
        {
            get { return AssemblyPullTime; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                AssemblyPullTime = value;
            }
        }

        public Double assemblyPullResistance
        {
            get { return AssemblyPullResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                AssemblyPullResistance = value;
            }
        }

        public Double assemblyBreakTime
        {
            get { return AssemblyBreakTime; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                AssemblyBreakTime = value;
            }
        }
        public Double assemblyBreakResistance
        {
            get { return AssemblyBreakResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                AssemblyBreakResistance = value;
            }
        }

        public Double anchorResistance
        {
            get { return AnchorResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                AnchorResistance = value;
            }
        }

        public Double mainPoleResistance
        {
            get { return MainPoleResistance; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                MainPoleResistance = value;
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