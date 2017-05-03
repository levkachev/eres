using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Trains.Interpolation.Entities;
using TrainMovement.Stuff;

namespace TrainMovement.Interpolation
{
    internal abstract class BaseModeRusi4
    {
        /// <summary>
        /// Характеристики
        /// </summary>
        private SortedList<Double, VFI> vfi;

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        public IEnumerable<VFI> ForceAndCurrent
        {
            get
            {
                return vfi.Values;
            }
            protected set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                vfi = SetForceAndCurrent(value);
            }
        }

        /// <summary>
        /// Преобразование в SortedList по скорости
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static SortedList<Double, VFI> SetForceAndCurrent(IEnumerable<VFI> value)
        {
            return value.ToSortedList(item => item.Velocity);
        }

        protected BaseModeRusi4()
        {
        }

        protected Double GetCurrent(KeyValuePair<Double, VFI> pair)
        {
            return (pair.Value.CurrentMax + pair.Value.CurrentMin) / 2;
        }

        protected Double GetForce(KeyValuePair<Double, VFI> pair)
        {
            return (pair.Value.ForceMax + pair.Value.ForceMin) / 2;
        }

        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="InvalidOperationException">Ни один элемент не удовлетворяет условию предиката <paramref name="predicate" />.– или –Исходная последовательность пуста.</exception>
        private Tuple<Double, Double> GetForceAndCurrent(Double velocity)
        {
            var vfi1 = vfi.Last(v => v.Key <= velocity);
            var vfi2 = vfi.First(v => v.Key >= velocity);

            var v1 = vfi1.Key;
            var v2 = vfi2.Key;

            var f1 = GetForce(vfi1);
            var f2 = GetForce(vfi2);
            var k1 = GetK(v1, v2, f1, f2);
            var force = k1 * v1 + GetB(v1, k1, f1);

            var c1 = GetCurrent(vfi1);
            var c2 = GetCurrent(vfi2);
            var k2 = GetK(v1, v2, c1, c2);
            var current = k2 * v1 + GetB(v1, k2, c1);

            return new Tuple<Double, Double>(force, current);
        }

        /// <summary>
        /// Коэффициент К прямой
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        private static Double GetK(Double x1, Double x2, Double y1, Double y2)
        {
            return (y1 - y2) / (x1 - x2);
        }

        /// <summary>
        /// Коэффициент В прямой
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="k"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        private static Double GetB(Double x1, Double k, Double y1)
        {
            return y1 - k * x1;
        }

        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="InvalidOperationException">Ни один элемент не удовлетворяет условию предиката <paramref name="predicate" />.– или –Исходная последовательность пуста.</exception>
        public Double GetForce(Double velocity)
        {
            return GetForceAndCurrent(velocity).Item1;
        }

        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="InvalidOperationException">Ни один элемент не удовлетворяет условию предиката <paramref name="predicate" />.– или –Исходная последовательность пуста.</exception>
        public Double GetCurrent(Double velocity)
        {
            return GetForceAndCurrent(velocity).Item2;
        }
    }
}
