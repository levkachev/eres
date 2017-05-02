using System;
using System.Collections.Generic;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Базовый класс для преобразования класса ограничения в отсортированное множество типа Limit -> (Double, Double) = (Координата, значение ограничения)
    /// </summary>
    public abstract class BaseConvertLimit<T>: ISortedSetLimits
    {
        /// <summary>
        /// Список ограничений по координате для перегона
        /// </summary>
        protected readonly SortedSet<Limit> sortedLimits;

        /// <summary>
        /// Список ограничений определенного класса вида (Double, Double)
        /// </summary>
        protected List<T> nativeLimits;

        /// <summary>
        /// Список ограничений скорости по координате для перегона
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<Limit> SortedLimits() => sortedLimits;

        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        protected IEnumerable<T> NativeLimits
        {
            get { return nativeLimits; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                nativeLimits = new List<T>(value);
            }
        }

        /// <summary>
        /// Метод, преобразующий ограничение в SortedSet(Double, Double)
        /// </summary>
        /// <returns></returns>
        protected abstract SortedSet<Limit> SetLimits();

        /// <summary>
        /// </summary>
        /// <param name="nativeList"></param>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        protected BaseConvertLimit(IEnumerable<T> nativeList)
        {
            NativeLimits = nativeList;
            sortedLimits = SetLimits();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="values" /> имеет значение null. </exception>
        public override String ToString()
        {
            return String.Join(" ; ", sortedLimits);
        }

        /// <summary>
        /// Реализует интерфейс ISortedSetLimits
        /// </summary>
        public IEnumerable<Limit> Limits => sortedLimits;
    }
}
