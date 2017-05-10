using System;
using System.Collections.Generic;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// План и профиль как одно ограничение
    /// </summary>
    public class ReliefLimits : BaseLimits
    {
        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="plan"/> is <see langword="null"/></exception>
        internal ReliefLimits(ISortedSetLimits plan, ISortedSetLimits profile)
        {
            Limits = reliefLimits(plan, profile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="planLimits"></param>
        /// <param name="profileLimits"></param>
        /// <returns></returns>
        private static SortedSet<Limit> reliefLimits(ISortedSetLimits planLimits, ISortedSetLimits profileLimits)
        {
            var tmpPlan = planLimits as List<Limit>;
            var tmpProfile = profileLimits as List<Limit>;
            if (tmpPlan == null)
                throw new ArgumentNullException(nameof(planLimits));

            if (tmpProfile == null)
                throw new ArgumentNullException(nameof(profileLimits));

            var countPlanLimits = tmpPlan.Count;
            var countProfileLimits = tmpProfile.Count;
            var resultSet = new SortedSet<Limit>();
            var indProfile = 0;
            var indPlan = 0;
            while (indPlan < countPlanLimits && indProfile < countProfileLimits)
            {
                var currentPlan = tmpPlan[indPlan];
                var currentProfile = tmpProfile[indProfile];
                var reliefLimit = currentPlan.Value + currentProfile.Value;
                Double reliefSpace;
                if (currentPlan.Space > currentProfile.Space)
                {
                    reliefSpace = currentProfile.Space;
                    ++indProfile;
                }
                else
                {
                    reliefSpace = currentPlan.Space;
                    ++indPlan;
                }
                var tmpLimitStructure = new Limit(reliefSpace, reliefLimit);
                resultSet.Add(tmpLimitStructure);
            }
            return resultSet;
        }

        /// <summary>
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Condition.</exception>
        public override Double GetLimit(Double space)
        {
            throw new NotImplementedException();
        }
    }
}
