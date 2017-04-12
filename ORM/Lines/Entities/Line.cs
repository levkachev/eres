using System;
using System.Collections.Generic;
using ORM.Base;
using ORM.Energy.Entities;


namespace ORM.Lines.Entities
{
    /// <summary>
    /// Линия
    /// </summary>
    public class Line : Entity<Line>
    {
        /// <summary>
        /// Наименование линии
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// Цвет линии 
        /// </summary>
        public virtual Color Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<PowerSupplyStation> PowerSupplyStation { get; set; }

        public Line()
        {
            PowerSupplyStation = new List<PowerSupplyStation>();
        }
    }
}
