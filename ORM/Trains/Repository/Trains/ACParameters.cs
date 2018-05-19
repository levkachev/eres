using System;

namespace ORM.Trains.Repository.Trains
{
    /// <summary>
    /// 
    /// </summary>
    public class ACParameters : BaseTrainParameters
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
            get => nbAuto;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                nbAuto = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="nbauto"></param>
        public ACParameters(BaseTrainParameters parameters,  Int32 nbauto) : base(parameters) => NBAuto = nbauto;
    }
}
