using System.Collections.Generic;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Класс, преобразующий список ограничений открфтых участков в отсортированное множество типа Limit(Double, Double)
    /// </summary>
    internal class OpenConvertLimitStage : BaseConvertLimit<OpenStage>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="nativeList"></param>
        internal OpenConvertLimitStage(IEnumerable<OpenStage> nativeList) : base(nativeList){}

        protected override SortedSet<Limit> SetLimits()
        {
            var resultSortedSet = new SortedSet<Limit>();
            var tmpVector = nativeLimits.ToArray();
            for (var i = 0; i < nativeLimits.Count; ++i)
            {
                var current = tmpVector[i];
                var speedLimit = new Limit(current.Finish - current.Start, current.KWosn);
                resultSortedSet.Add(speedLimit);
            }
            return resultSortedSet;
        }
    }
}
