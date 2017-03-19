using System;

namespace TrainMovement.Machine
{
    [Serializable]
    public class ACMachine : BaseMachine
    {
        /// <summary>
        /// Максимальное напряжение двигателя FLOAT for AC
        /// </summary>
        public Double UMax { get; protected set; }
    }
}
