using System;
using System.Collections.Generic;
using ORM.OldHelpers;
using ORM.Lines.Entities;
using static System.Math;

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
        internal NMConvertLimitStage(IEnumerable<NMLine> nmStage) : base(nmStage) {}

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        protected override SortedSet<Limit> SetLimits()
        {
            var resultSortedSet = new SortedSet<Limit>();

            var tmpVector = nativeLimits.ToArray();
           
            Double newPiketage;
            var space = 0.0;
            const Double valuePiketage = 100.0;

            var current = tmpVector[0];
            var next = tmpVector[1];
            var lastWrittenPiketage = 0.0;
            var wasWritten = false;

            var direction = current.Piketage < next.Piketage;

            for (var i = 0; i < tmpVector.Length - 1; ++i)
            {
                current = tmpVector[i];
                next = tmpVector[i + 1];
                newPiketage = current.Piketage;
                
                while (Abs(Truncate(newPiketage) - Truncate(next.Piketage)) >= 1)
                {
                    Double length;
                    if (Abs(newPiketage - current.Piketage) < 1)
                    {
                        length = current.Length;
                        if (wasWritten)
                            space -= GetDistanceInMeters(newPiketage, lastWrittenPiketage);
                    }
                    else
                    {
                        length = valuePiketage;
                    }

                    newPiketage = AddPiketage(newPiketage, direction);
                      
                    lastWrittenPiketage = newPiketage;
                    wasWritten = true;

                    space += length;

                    resultSortedSet.Add(new Limit(space, newPiketage));
                }
            }

            current = tmpVector[nativeLimits.Count - 1];
            space -= GetDistanceInMeters(current.Piketage, lastWrittenPiketage);
            resultSortedSet.Add(new Limit(space, current.Piketage));
            space += current.Length;
            


            newPiketage = AddPiketage(current.Piketage, direction);
            resultSortedSet.Add(new Limit(space, newPiketage));

            return resultSortedSet;
        }

        private static Double GetDistanceInMeters(Double newPiketage, Double lastWrittenPiketage) => Abs(newPiketage - lastWrittenPiketage) * 100;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="limits"></param>
        /// <returns></returns>
        public static IEnumerable<Limit> GetLimits(IEnumerable<NMLine> limits) => new NMConvertLimitStage(limits).Limits;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="piketage"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private static Double AddPiketage(Double piketage, Boolean direction) => direction ? piketage + 1.0 : piketage - 1.0;
    }
}
