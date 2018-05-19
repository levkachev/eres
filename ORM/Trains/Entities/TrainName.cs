using System;
using ORM.Base;
using System.Collections.Generic;
using ORM.Trains.Interpolation.Entities;
    
namespace ORM.Trains.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Вид подвижного состава (тип --> { AC | DC }, вид --> { "Яуза" | "Русич" | "Ока" | "Москва" })
    /// </summary>
    public class TrainName : NamedEntity<TrainName>
    {
        /// <inheritdoc />
        /// <summary>
        /// Наименование поезда.
        /// </summary>
        public override String Name { get; protected set; }

        /// <summary>
        /// Тип двигателя (AC или DC)
        /// </summary>
        public virtual MotorType MotorType { get; protected set; }

        /// <summary>
        /// Дополнительные параметры
        /// </summary>
        public virtual IEnumerable<AdditionalParameter> AdditionalParameters { get; protected set; } = new List<AdditionalParameter>();

        /// <summary>
        /// Тяговые и скоростные характеристики для текущего вида подвижного состава.
        /// </summary>
        public virtual IEnumerable<ElectricTractionCharacteristics> Characteristics { get; protected set; } = new List<ElectricTractionCharacteristics>();
    } 
}
