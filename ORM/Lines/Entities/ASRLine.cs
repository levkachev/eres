using System;
using ORM.Base;



namespace ORM.Lines.Entities
{
    /// <summary>
    /// Автоматическое регулирование скорости. Данные по Линии
    /// </summary>
    public class ASRLine : NamedEntity<ASRLine>
    {
        /// <summary>
        /// Наименование линии
        /// </summary>
        public override String Name { get; protected set; }

        /// <summary>
        /// Ограничения 
        /// </summary>
        public virtual Double Limit { get; set; }

        /// <summary>
        /// пикетаж 
        /// </summary>
        public virtual Double Piketage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Track Track { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $" {Name} {Limit} {Piketage}";
    }
}

