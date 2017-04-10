using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Train.Entities
{
    public class MachineBaseParametres
    {
        /// <summary>
        /// FLOAT NOT NULL--Время сбора силовой цепи на ход tsborp
        /// </summary>
        public Double AssemblyPullTime { get; protected set; }

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

        public MachineBaseParametres(Double assemblyPullTime)
        {
            AssemblyPullTime = assemblyPullTime;
        }

        public MachineBaseParametres() { }
    }
}
