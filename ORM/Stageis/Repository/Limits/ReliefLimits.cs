﻿using System;
using System.Collections.Generic;
using System.Linq;

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
        internal ReliefLimits(IEnumerable<Limit> plan, IEnumerable<Limit> profile)
        {
            Limits = reliefLimits(plan, profile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="planLimits"></param>
        /// <param name="profileLimits"></param>
        /// <returns></returns>
        private static SortedSet<Limit> reliefLimits(IEnumerable<Limit> planLimits, IEnumerable<Limit> profileLimits)
        {
            var tmpPlan = planLimits.ToList();
            var tmpProfile = profileLimits.ToList();
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
        /// Выдает все ограничения в диапазоне
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <returns></returns>
        public IEnumerable<Limit> GetReliefLimitsIn(Double head, Double tail)
        {
            return  Limits
                .TakeWhile(s => s.Space<=head && s.Space >=tail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Limit GetFirstLimit(Double head)
        {
            return Limits.FirstOrDefault(s => s.Space >= head);
        }
    }
}
