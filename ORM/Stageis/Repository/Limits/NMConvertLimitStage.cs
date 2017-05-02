using System;
using System.Collections.Generic;
using ORM.Lines.Entities;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Немерные пикеты преобразуем в последовательность пикет - значение. Для немерных оставляем значение, для остальных = 100 м
    /// </summary>
    public class NMConvertLimitStage : BaseConvertLimit<NMLine>
    {
        /// <summary>
        /// </summary>
        /// <param name="nmStage"></param>
        /// <exception cref="ArgumentNullException">value is <see langword="null" /></exception>
        internal NMConvertLimitStage(IEnumerable<NMLine> nmStage) : base(nmStage)
        {}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override SortedSet<Limit> SetLimits()
        {
            var resultSortedSet = new SortedSet<Limit>();

            var tmpVector = nativeLimits.ToArray();
            var current = tmpVector[0];
            var next = tmpVector[1];
            Double newPiketage;
            Double space = 0.0;
            const Double valuePiketage = 100.0;
            var direction = current.Piketage < next.Piketage;
            newPiketage = AddPiketage(current.Piketage, direction);
            var newLimit = new Limit(space, newPiketage);
            resultSortedSet.Add(newLimit);
            for (var i = 0; i < nativeLimits.Count - 1; ++i)
            {
                current = tmpVector[i];
                next = tmpVector[i + 1];
                space = space + current.Length;
                newLimit = new Limit(space, current.Piketage);
                resultSortedSet.Add(newLimit);
                newPiketage = AddPiketage(current.Piketage, direction);
                while (newPiketage < next.Piketage)
                {
                    space = space + valuePiketage;
                    newLimit = new Limit(space, current.Piketage);
                    resultSortedSet.Add(newLimit);
                    newPiketage = AddPiketage(current.Piketage, direction);
                }
            }
            return resultSortedSet;
        }

        public static IEnumerable<Limit> GetLimits(IEnumerable<NMLine> limits)
        {
            return new NMConvertLimitStage(limits).Limits;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="piketage"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private Double AddPiketage(Double piketage, Boolean direction)
        {
            return direction ? piketage - 1.0 : piketage + 1.0;
        }
    }
}
