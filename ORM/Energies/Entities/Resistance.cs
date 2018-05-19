using System;
using ORM.Base;

namespace ORM.Energies.Entities
{
    /// <summary>
    /// Сопротивление фидера
    /// </summary>
    public class Resistance : Entity<Resistance>
    {
        /// <summary>
        /// Количество кабелей, шт
        /// </summary>
        public virtual Int32 Count { get; protected set; }

        /// <summary>
        /// Площадь поперечного сечения кабеля, мм2
        /// </summary>
        public virtual Int32 Square { get; protected set; }

        /// <summary>
        /// Длина фидера, м
        /// </summary>
        public virtual Double Length { get; protected set; }

        /// <summary>
        /// Тип кабеля
        /// </summary>
        public virtual ResistanceType ResistanceType { get; protected set; }

        /// <summary>
        /// Фидер
        /// </summary>
        public virtual Feeder Feeder { get; protected set; }
    }
}
