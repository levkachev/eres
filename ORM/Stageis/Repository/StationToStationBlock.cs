using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Stageis.Repository.Limits;

namespace ORM.Stageis.Repository
{
    /// <summary>
    /// Класс перегон, имеющий логику взаимодействия с поездом
    /// </summary>
    public class StationToStationBlock
    {
        /// <summary>
        /// Список всех ограничений
        /// </summary>
        private List<ILimits> limits;

        /// <summary>
        /// Список всех ограничений
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        internal IEnumerable<ILimits> Limits
        {
            get { return limits; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                limits = new List<ILimits>(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal StationToStationBlock(IEnumerable<ILimits> limits)
        {
            Limits = limits;
        }

        /// <summary>
        /// Выдает максимальную скорость хода по перегону от координаты
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        public Double GetMaxVelocity(Double space)
        {
            return Limits.OfType<AllVelocityLimits>().First().GetLimit(space);
        }
    }
}
