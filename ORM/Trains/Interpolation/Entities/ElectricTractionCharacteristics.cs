using System;
using ORM.Base;
using ORM.Trains.Entities;

namespace ORM.Trains.Interpolation.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// характеристики 
    /// </summary>
    public class ElectricTractionCharacteristics : Entity<ElectricTractionCharacteristics>
    {
        /// <summary>
        /// скорость
        /// </summary>
        public virtual Double Velocity { get; protected set; }

        /// <summary>
        /// сила тяги (торможения) max
        /// </summary>
        public virtual Double ForceMax { get; protected set; }

        /// <summary>
        /// сила тяги (торможения) min
        /// </summary>
        public virtual Double ForceMin { get; protected set; }

        /// <summary>
        /// ток max
        /// </summary>
        public virtual Double CurrentMax { get; protected set; }

        /// <summary>
        /// ток min
        /// </summary>
        public virtual Double CurrentMin { get; protected set; }

        /// <summary>
        /// режим управления
        /// </summary>
        public virtual ModeControl ModeControl { get; protected set; }

        /// <summary>
        /// масса поезда
        /// </summary>
        public virtual Mass Mass { get; protected set; }

        /// <summary>
        /// наименование поезда
        /// </summary>
        public virtual TrainName Train { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $"{Velocity}, {ForceMax}, {ForceMin}, {CurrentMax}, {CurrentMin}";
    }
}
