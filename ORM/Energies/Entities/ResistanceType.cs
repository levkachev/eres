using System;
using ORM.Base;

namespace ORM.Energies.Entities
{
    /// <summary>
    /// Справочник кабелей
    /// </summary>
    public class ResistanceType: NamedEntity<ResistanceType>
    {
        /// <summary>
        /// Наименование кабеля
        /// </summary>
        public override String Name { get; protected set; }

        /// <summary>
        /// Сопротивление кабеля
        /// </summary>
        public virtual Double Resistance { get; protected set; }
    }
}
