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
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                nbAuto = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ACParametres(Int32 numberCars, Double carLength, Double unladenWeight, Double breakAverage, Double netResistancePullFactor, Double aerodynamicDragFactor, Double netResistenceCoastingFactor1, Double netResistenceCoastingFactor2, Double netResistenceCoastingFactor3, Double trainEqvivalentSurface, Double inertiaRotationFactor, Double ownNeedsElectricPower, Int32 nbAuto) : base(numberCars, carLength, unladenWeight,  breakAverage,  netResistancePullFactor,  aerodynamicDragFactor,  netResistenceCoastingFactor1,  netResistenceCoastingFactor2,  netResistenceCoastingFactor3,  trainEqvivalentSurface,  inertiaRotationFactor,  ownNeedsElectricPower)
        {
            NBAuto = nbAuto;
        }
    }
}
