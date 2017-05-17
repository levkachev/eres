using System;
using System.Collections.Generic;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Ограничения типа токораздел
    /// </summary>
    public class CurrentBlockLimits : BaseLimits
    {
        /// <exception cref="ArgumentNullException"><paramref name="seriesOfLimits" /> is <see langword="null" /></exception>
        internal CurrentBlockLimits(params IEnumerable<Limit>[] seriesOfLimits): base(seriesOfLimits){}
    }
}
