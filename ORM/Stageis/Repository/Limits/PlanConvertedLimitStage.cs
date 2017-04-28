using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// План перегона
    /// </summary>
    internal class PlanConvertedLimitStage : BaseConvertLimit<PlanStage>
    {
        /// <summary>
        /// Константа для пересчета значений радиуса в систему профиля
        /// </summary>
        const Double convertFactor = 630.0;

        /// <summary>
        /// Пересчет значений плана к системе профиля
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<Limit> ConvertedPlan() => convertPlanToProfile();

        /// <summary>
        /// Конструктор класс план
        /// </summary>
        /// <exception cref="ArgumentNullException">value is <see langword="null" /></exception>
        internal PlanConvertedLimitStage(IEnumerable<PlanStage> planLimits):base(planLimits) {}

        /// <summary>
        /// Метод для конвертации в систему профиля
        /// </summary>
        /// <returns></returns>
        private SortedSet<Limit> convertPlanToProfile()
        {
            var tmpVector = sortedLimits.ToArray();
            var resultSet = new SortedSet<Limit>();
            for (var i = 0; i < sortedLimits.Count; ++i)
            {
                var current = tmpVector[i];
                if (isZero(current.Value))
                    resultSet.Add(current);
                else
                {
                    var convertedRadius = convertFactor / current.Value;
                    var tmpLimitStructure = new Limit(current.Space, convertedRadius);
                    resultSet.Add(tmpLimitStructure);
                }
            }
            return resultSet;
        }

        /// <summary>
        /// Сравнение с нулем числа с плавающей точкой
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Boolean isZero(Double value)
        {
            return Math.Abs(value) < Double.Epsilon;
        }

        /// <summary>
        /// Сравнение двух чисел с плавающей точкой
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        private static Boolean isEqual(Double lha, Double rha)
        {
            return Math.Abs(lha - rha) < Double.Epsilon;
        }

        protected override SortedSet<Limit> SetLimits()
        {
            var resultSortedSet = new SortedSet<Limit>();
            var tmpVector = nativeLimits.ToArray();
            for (var i = 0; i < nativeLimits.Count; ++i)
            {
                var current = tmpVector[i];
                var speedLimit = new Limit(current.End_Radius, current.Radius);
                resultSortedSet.Add(speedLimit);
            }
            return resultSortedSet;
        }


    }
}
