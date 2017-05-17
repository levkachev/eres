using System;

namespace ORM.Trains.Repository.Machine
{
    /// <summary>
    /// Общие параметры для двигателя
    /// </summary>
    public class BaseMachine
    {
        /// <summary>
        /// Время сбора силовой цепи на ход tsborp
        /// </summary>
        private Double assemblyPullTime;

        /// <summary>
        /// 
        /// </summary>
        private String name;

        /// <summary>
        /// Время сбора силовой цепи на Тормоз
        /// </summary>
        private Double assemblyBreakTime;

        /// <summary>
        /// Время разбора силовой цепи
        /// </summary>
        private Double disassemblyPowerCircuitTime;

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set"><paramref name="value"/> length is zero.</exception>
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
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
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
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
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
        /// FLOAT NOT NULL --Время разбора силовой цепи trasb
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
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
        /// <param name="assemblyBreakTime"></param>
        /// <param name="assemblyPullTime"></param>
        /// <param name="trainName"></param>
        /// <param name="disassemblyPowerCircuitTime"></param>
        /// <exception cref="ArgumentOutOfRangeException">less zero.</exception>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        public BaseMachine(Double disassemblyPowerCircuitTime, Double assemblyBreakTime, Double assemblyPullTime, String trainName)
        {
            DisassemblyPowerCircuitTime = disassemblyPowerCircuitTime;
            AssemblyBreakTime = assemblyBreakTime;
            AssemblyPullTime = assemblyPullTime;
            Name = trainName;
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseMachine() { }
    }
}
