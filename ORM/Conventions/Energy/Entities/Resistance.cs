using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Base;

namespace ORM.Energy.Entities
{
    /// <summary>
    /// Сопротивление фидера
    /// </summary>
    public class Resistance : Entity<Resistance>
    {
        /// <summary>
        /// Количество кабелей
        /// </summary>
        public virtual Int32 Count { get; set; }

        /// <summary>
        /// Площадь поперечного сечения кабеля, мм2
        /// </summary>
        public virtual Int32 Square { get; set; }

        /// <summary>
        /// Длина фидера, м
        /// </summary>
        public virtual Double Length { get; set; }

        /// <summary>
        /// Тип кабеля
        /// </summary>
        public virtual Type_Resistance Type_Resistance { get; set; }

        /// <summary>
        /// Фидер
        /// </summary>
        public virtual Feeder Feeder  { get; set; }


       
    }
}
