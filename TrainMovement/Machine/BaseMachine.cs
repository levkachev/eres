using System;

namespace TrainMovement.Machine
{
    [Serializable]
    public abstract class BaseMachine
    {
        private Double assemblyPullTime;

        private String name;

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
        /// FLOAT NOT NULL--Время сбора силовой цепи на ход tsborp
        /// </summary>
        public Double AssemblyPullTime
        {
            get { return assemblyPullTime; }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                assemblyPullTime = value;
            }
        }

        /// <summary>
        /// FLOAT NOT NULL--Время сбора силовой цепи на Тормоз tsborB
        /// </summary>
        public Double AssemblyBreakTime { get; protected set; }

        /// <summary>
        /// Номинальное напряжение двигателя FLOAT NOT NULL
        /// </summary>
        public Double UNominal { get; protected set; }

        /// <summary>
        /// FLOAT NOT NULL --Время разбора силовой цепи trasb
        /// </summary>
        public Double DisassemblyPowerCircuitTime { get; protected set; }
       
    }
}
