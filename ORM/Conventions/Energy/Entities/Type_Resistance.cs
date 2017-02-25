using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Base;

namespace ORM.Energy.Entities
{
    /// <summary>
    /// Справочник кабелей
    /// </summary>
    public class Type_Resistance: Entity<Type_Resistance>
    {
        /// <summary>
        /// Тип кабеля
        /// </summary>
        public virtual String Type { get; set; }

        /// <summary>
        /// Сопротивление кабеля
        /// </summary>
        public virtual Double Resistance { get; set; }
    }
}
