using System;

namespace ORM.Trains.Repository.Machine
{
    /// <summary>
    /// Параметры для AC двигателя 
    /// </summary>
    public class ACMachine : BaseMachine
    {
        /// <summary>
        /// 
        /// </summary>
        private Double umax;

        /// <summary>
        /// Номинальное напряжение двигателя
        /// </summary>
        private Double uNominal;

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero.</exception>
        public Double Umax
        {
            get { return umax; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                umax = value;
            }
        }

        /// <summary>
        /// Номинальное напряжение двигателя FLOAT NOT NULL
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">less zero</exception>
        public Double Unominal
        {
            get { return uNominal; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                uNominal = value;
            }
        }
        public ACMachine(Double disassemblyPowerCircuitTime, Double assemblyBreakTime, String trainName, Double umax, Double uNominal) : base(disassemblyPowerCircuitTime, assemblyBreakTime, assemblyBreakTime, trainName)
        {
            Umax = umax;
            Unominal = Unominal;
        }
    }
}
