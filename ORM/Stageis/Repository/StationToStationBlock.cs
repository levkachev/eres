using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Stageis.Repository.Limits;
using ORM.Helpers;

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

        /// <summary>
        /// По заданной координате рассчитывает дополнительнок сопротивление от клонов и кривых
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        /// <exception cref="NotImplementedException">Condition.</exception>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        public Double GetAdditionalResistance(Double space)
        {
            return Limits.OfType<ReliefLimits>().First().GetLimit(space);
        }

        /// <summary>
        /// Рассчитать коэффициент, зависящий от открытых участков для расчета основного сопротивления движения
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        public Double GetAerodynamicFactor(Double space)
        {
            return Limits.OfType<OpenLimits>().First().GetLimit(space);
        }

        /// <summary>
        /// Возвращает возможность ехать в тяге (тормозе). Ехать можно в тяге, если поезд не на токоразделе. Метод возвращает true(1). Когда координата совпадает с токоразделом, метод возвращает false(0).
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        public Boolean CanPull(Double space)
        {
            var tmp = Limits.OfType<CurrentBlockLimits>().First().GetLimit(space);
            return MathHelper.IsEqual(1, tmp);
        }
    }
}
