using System;
using System.Collections.Generic;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Класс ограничений скорости по перегону
    /// </summary>
    internal class VelocityConvertLimitStage : BaseConvertLimit<LimitStage>
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null" /></exception>
        internal VelocityConvertLimitStage(IEnumerable<LimitStage> velocityLimits) : base(velocityLimits) {}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
