using System;
using System.Collections.Generic;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Класс, рассчитывающий ограничение скорости по заданной координате
    /// </summary>
    public class AllVelocityLimits : BaseLimits
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seriesOfLimits"></param>
        /// <exception cref="ArgumentNullException"><paramref name="seriesOfLimits"/> is <see langword="null"/></exception>
        public AllVelocityLimits(params IEnumerable<Limit>[] seriesOfLimits) : base(seriesOfLimits){}
    }
}