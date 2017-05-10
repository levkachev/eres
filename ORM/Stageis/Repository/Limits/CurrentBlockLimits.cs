using System;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Ограничения типа токораздел
    /// </summary>
    internal class CurrentBlockLimits : BaseLimits
    {
        /// <exception cref="ArgumentNullException"><paramref name="seriesOfLimits" /> is <see langword="null" /></exception>
        internal CurrentBlockLimits(params ISortedSetLimits[] seriesOfLimits): base(seriesOfLimits){}
    }
}
