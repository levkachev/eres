using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Trains;

namespace ORM.Trains.Repository.Trains
{
    /// <summary>
    /// 
    /// </summary>
    public class ACParameters : BaseTrainParametres
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

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="nbauto"></param>
        public ACParameters(BaseTrainParametres parameters,  Int32 nbauto) : base(parameters.NumberCars, parameters.CarLength, parameters.UnladenWeight, parameters.BAverage, parameters.NetResistencePullFactor, parameters.AerodynamicDragFactor, parameters.NetResistenceCoastingFactor1, parameters.NetResistenceCoastingFactor2, parameters.NetResistenceCoastingFactor3, parameters.TrainEqvivalentSurface, parameters.InertiaRotationFactor, parameters.OwnNeedsElectricPower, parameters.Name)
        {
            NBAuto = nbauto;
        }
    }
}
