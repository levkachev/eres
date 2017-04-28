using System;
using System.Collections.Generic;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// 
    /// </summary>
    internal class ASRConvertLimitStage : BaseConvertLimit<ASRStage>
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null" /></exception>
        internal ASRConvertLimitStage(IEnumerable<ASRStage> asrLimits) : base(asrLimits) { }

        protected override SortedSet<Limit> SetLimits()
        {
            var resultSortedSet = new SortedSet<Limit>();
            var tmpVector = nativeLimits.ToArray();
            for (var i = 0; i < nativeLimits.Count; ++i)
            {
                var current = tmpVector[i];
                var speedLimit = new Limit(current.EndVelocity, current.Velocity);
                resultSortedSet.Add(speedLimit);
            }
            return resultSortedSet;
        }
    }
}
