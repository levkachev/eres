using System;

namespace TrainMovement.Machine
{
    [Serializable]
    public class BaseMachine
    {
        /// <summary>
        /// Номинальное напряжение двигателя FLOAT NOT NULL
        /// </summary>
        public Double UNominal { get; protected set; }

        /// <summary>
        /// FLOAT NOT NULL --Время разбора силовой цепи trasb
        /// </summary>
        public Double DisassemblyPowerCircuitTime { get; protected set; }

        /// <summary>
        /// FLOAT NOT NULL--Время сбора силовой цепи на ход tsborp
        /// </summary>
        private Double assemblyPullTime;

        /// <summary>
        /// FLOAT NOT NULL--Время сбора силовой цепи на Тормоз tsborB
        /// </summary>
        private Double assemblyBreakTime;
    }
}
