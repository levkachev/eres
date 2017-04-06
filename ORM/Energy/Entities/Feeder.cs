using System;
using ORM.Base;

namespace ORM.Energy.Entities
{
    /// <summary>
    /// Фидер
    /// </summary>
    public class Feeder : Entity<Feeder>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// Пикетаж
        /// </summary>
        public virtual Double Piketag { get; set; }

        /// <summary>
        /// Тип фидера
        /// </summary>
        public virtual String FeederType { get; set; }

        /// <summary>
        /// Сопротивление фидера
        /// </summary>
        public virtual Double Resistance { get; set; }

        /// <summary>
        /// Тяговая подстанция
        /// </summary>
        public virtual PowerSupplyStation PSS { get; set; }

        public override String ToString()
        {
            return String.Format($"{Resistance}, {Piketag}, {Name}");
        }

    }
}
