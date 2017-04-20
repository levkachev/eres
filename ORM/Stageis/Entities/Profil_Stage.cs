using System;
using ORM.Base;
using System.Collections.Generic;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// Профиль перегона
    /// </summary>
    public class Profil_Stage : Entity<Profil_Stage>
    {
        /// <summary>
        /// Уклон
        /// </summary>
        public virtual Double Slope { get; set; }


        /// <summary>
        /// Граница уклона
        /// </summary>
        public virtual Double End_Slope { get; set; }

        
        /// <summary>
        /// 
        /// </summary>
        public virtual Stage Stage { get; set; }
        







    }
}
