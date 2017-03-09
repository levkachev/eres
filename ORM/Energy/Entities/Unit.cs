using System;
using System.Collections.Generic;
using ORM.Base;

namespace ORM.Energy.Entities
{
    /// <summary>
    /// Преобразовательный агрегат
    /// </summary>
    public class Unit : Entity<Unit>
    {
        /// <summary>
        /// Количество агрегатов
        /// </summary>
        public virtual Int32 UnitCount { get; set; }

        /// <summary>
        /// Количество диодов
        /// </summary>
        
        public virtual Int32 DiodCount { get; set; }

        /// <summary>
        /// Количество трансформа-торов
        /// </summary>
        public virtual Int32 TransformatorCount { get; set; }

        /// <summary>
        /// Наименование преобразовательного агрегата
        /// </summary>
        public virtual Unit_Name Unit_Name { get; set; }

        /// <summary>
        /// Тяговая подстанция
        /// </summary>
        public virtual PowerSupplyStation PSS { get; set; }

        /// <summary>
        /// Выпрямитель
        /// </summary>
        public virtual IList<Diod> Diods { get; set; }

        /// <summary>
        /// Трансформатор
        /// </summary>
        public virtual IList<PowerConvert> PowerConverts { get; set; }

        
        public Unit()
        {
            Diods = new List<Diod>();
            PowerConverts = new List<PowerConvert>();

        }

        public override String ToString()
        {
            return String.Format($"{UnitCount}, {DiodCount}, {TransformatorCount}");
        }

    }
}
    
    
 