using System;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Класс, рассчитывающий ограничение скорости по заданной координате
    /// </summary>
    internal class AllVelocityLimits : BaseLimits
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seriesOfLimits"></param>
        /// <exception cref="ArgumentNullException"><paramref name="seriesOfLimits"/> is <see langword="null"/></exception>
        internal AllVelocityLimits(params ILimits[] seriesOfLimits) : base(seriesOfLimits){}
    }
}