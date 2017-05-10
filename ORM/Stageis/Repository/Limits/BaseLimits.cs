using System;
using System.Collections.Generic;
using System.Linq;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Абстрактный класс для ограничений одного типа. Реализует метод "Рассчитай ограничение"
    /// </summary>
    public abstract class BaseLimits : ILimits
    {
        /// <summary>
        /// Список ограничений скорости
        /// </summary>
        private SortedSet<Limit> limits;

        /// <summary>
        /// Список ограничений скорости
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set">Thrown when the arguments are <see langword="null"/></exception>
        public IEnumerable<Limit> Limits
        {
            get { return limits; }
            protected set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                limits = new SortedSet<Limit>(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public virtual Double GetLimit(Double space)
        {
            var result = Limits.FirstOrDefault(item => item.Space >= space);
            if (result == null)
                throw new ArgumentOutOfRangeException(nameof(space));

            return result.Value;
        }

        /// <exception cref="ArgumentNullException"><paramref name="seriesOfLimits"/> is <see langword="null"/></exception>
        protected BaseLimits(params ISortedSetLimits[] seriesOfLimits)
        {
            if (seriesOfLimits == null)
                throw new ArgumentNullException(nameof(seriesOfLimits));
            Limits = seriesOfLimits.Where(series => series != null).SelectMany(series => series.Limits);
        }
    }
}