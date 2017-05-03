using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Trains.Interpolation.Entities;

namespace TrainMovement.Interpolation
{
    internal abstract class BaseModeRusi4
    {
        /// <summary>
        /// Характеристики
        /// </summary>
        private SortedList<Double, VFI> vfi;

        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        public IEnumerable<VFI> ForceAndCurrent
        {
            get
            { return vfi.Values; }
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
            var tmpList = value.ToList();
            var result = new SortedList<Double, VFI>();
            foreach (var item in tmpList)
            {
                var current = item;
                result.Add(current.Velocity, current);
            }
            return result;
        }

        protected BaseModeRusi4()
        {
        }

        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="InvalidOperationException">Ни один элемент не удовлетворяет условию предиката <paramref name="predicate" />.– или –Исходная последовательность пуста.</exception>
        private Tuple<Double, Double> GetForceAndCurrent(Double velocity)
        {
            var vfi1 = vfi.Last(v => v.Key <= velocity);
            var vfi2 = vfi.First(v => v.Key >= velocity);
            var v1 = vfi1.Key;
            var v2 = vfi2.Key;
            var f1 = (vfi1.Value.ForceMax + vfi1.Value.ForceMin) / 2;
            var f2 = (vfi2.Value.ForceMax + vfi2.Value.ForceMin) / 2;
            var k = GetK(v1, v2, f1, f2);
            var force = k * v1 + GetB(v1, k, f1);

            var c1 = (vfi1.Value.CurrentMax + vfi1.Value.CurrentMin) / 2;
            var c2 = (vfi2.Value.CurrentMax + vfi2.Value.CurrentMin) / 2;
            k = GetK(v1, v2, c1, c2);
            var current = k * v1 + GetB(v1, k, c1);
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
