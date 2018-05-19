using System;
using ORM.Base;
using System.Collections.Generic;
using ORM.Stageis.Entities;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Станция
    /// </summary>
    public class Station : NamedEntity<Station>
    {
        /// <inheritdoc />
        /// <summary>
        /// Название станции
        /// </summary>
        public override String Name { get; protected set; }

        /// <summary>
        /// пикетаж 
        /// </summary>
        public virtual Double Piketage { get; set; }

        /// <summary>
        /// сокращенное наименование
        /// </summary>
        public virtual String ShortName { get; set; }

        /// <summary>
        /// линия
        /// </summary>
        public virtual Line Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $" {Name} {Piketage}";
    }
}