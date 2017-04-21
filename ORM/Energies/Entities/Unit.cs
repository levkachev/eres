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
        public virtual PowerSupplyStation PowerSupplyStation { get; set; }

        /// <summary>
        /// Выпрямители
        /// </summary>
        public virtual IEnumerable<Diod> Diods { get; set; }

        /// <summary>
        /// Трансформаторы
        /// </summary>
        public virtual IEnumerable<PowerConvert> PowerConverts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Unit()
        {
            Diods = new SortedSet<Diod>();
            PowerConverts = new SortedSet<PowerConvert>();

        }

        public override String ToString()
        {
            return $"Units count = {UnitCount}, Diods count = {DiodCount}, transformators count = " +
                   $"{TransformatorCount}";
        }
    }
}
        
 