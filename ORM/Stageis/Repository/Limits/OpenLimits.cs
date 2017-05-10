﻿using System;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// 
    /// </summary>
    internal class OpenLimits : BaseLimits
    {
        /// <summary>
        /// </summary>
        /// <param name="seriesOfLimits"></param>
        /// <exception cref="ArgumentNullException"><paramref name="seriesOfLimits"/> is <see langword="null"/></exception>
        internal OpenLimits(params ISortedSetLimits[] seriesOfLimits) : base(seriesOfLimits) {}
    }
}
