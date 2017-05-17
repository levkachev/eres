using System;
using System.Collections.Generic;
using System.Linq;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Определение координаты на линии, зная расстояние от начала перегона
    /// </summary>
    public class NMLimits : BaseLimits
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="seriesOfLimits"></param>
        /// <exception cref="ArgumentNullException"><paramref name="seriesOfLimits" /> is <see langword="null" /></exception>
        internal NMLimits(params IEnumerable<Limit>[] seriesOfLimits) : base(seriesOfLimits) { }

        /// <summary>
        /// Дает координату на линии по проехавшему от начала перегона пути
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown when the arguments are <see langword="null"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        public override Double GetLimit(Double space)
        {
            var limit = Limits.FirstOrDefault(item => item.Space >= space);
            if (limit == null)
                throw new ArgumentOutOfRangeException(nameof(space));

            var tmpPiketage = limit.Value;
            var direction = Limits.First() < Limits.Last();

            var deltaSpace = space - limit.Space;
            return direction ? tmpPiketage + deltaSpace/100 : tmpPiketage - deltaSpace/100;
        }
    }
}
