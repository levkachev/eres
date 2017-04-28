using System;
using System.Collections.Generic;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Профиль перегона
    /// </summary>
    internal class ProfileConvertLimitStage : BaseConvertLimit<ProfileStage>
    {
        /// <summary>
        /// Профиль перегона
        /// </summary>
        /// <exception cref="ArgumentNullException">value is <see langword="null" /></exception>
        internal ProfileConvertLimitStage(IEnumerable<ProfileStage> profileLimits) : base(profileLimits) { }

        protected override SortedSet<Limit> SetLimits()
        {
            var resultSortedSet = new SortedSet<Limit>();
            var tmpVector = nativeLimits.ToArray();
            for (var i = 0; i < nativeLimits.Count; ++i)
            {
                var current = tmpVector[i];
                var speedLimit = new Limit(current.End_Slope, current.Slope);
                resultSortedSet.Add(speedLimit);
            }
            return resultSortedSet;
        }
    }
}
