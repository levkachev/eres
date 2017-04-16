using System;

namespace ORM.Trains.Repository.Trains
{
    /// <summary>
    /// 
    /// </summary>
    public class ACParametres : BaseTrainParametres
    {
        /// <summary>
        /// 
        /// </summary>
        private Int32 nbAuto;

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Int32 NBAuto
        {
            get { return nbAuto; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                nbAuto = value;
            }
        }
    }
}
