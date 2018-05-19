using System;
using ORM.Base;

namespace ORM.Lines.Entities
{
    /// <summary>
    /// Профиль линии
    /// </summary>
    public class ProfileLine : Entity<ProfileLine>
    {
        /// <summary>
        /// Уклон
        /// </summary>
        public virtual Double Slope { get; set; }

        /// <summary>
        /// Пикетаж  
        /// </summary>
        public virtual Double Piketage { get; set; }
      
        /// <summary>
        /// номер пути
        /// </summary>
        public virtual Track Track { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $" {Slope} {Piketage} ";
    }
}