using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using ORM.Helpers;
using ORM.Trains.Entities;
using ORM.Trains.Interpolation.Entities;
using TrainMovement.ModeControl;
using TrainMovement.PhisicalHelper;
using TrainMovement.Stuff;
using TrainMovement.Train;

namespace TrainMovement.Interpolation
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseModeRusi4<T> : IModeControl
        where T : IModeControl
    {
        /// <summary>
        /// Instance of singleton object.
        /// </summary>
        private static BaseModeRusi4<T> instance;

        /// <summary>
        /// 
        /// </summary>
        public MassMass Mass;// { get; protected set; }

        /// <exception cref="InvalidOperationException">Condition.</exception>
        protected static TBaseModeRusi4 GetInstance<TBaseModeRusi4>(MassMass mass) 
            where TBaseModeRusi4 :  BaseModeRusi4<T>//, new()
        {
            if (instance == null)
            {
                var list = typeof(TBaseModeRusi4).GetConstructors();

                var ctor = typeof(TBaseModeRusi4).GetConstructor(
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    new Type[] { typeof(MassMass) },
                    null);
                if (ctor == null)
                    throw new InvalidOperationException();

                instance = ctor.Invoke(new Object[] { mass }) as BaseModeRusi4<T>;
            }
            return instance as TBaseModeRusi4;
        }

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

        /// <summary>
        /// 
        /// </summary>
        protected BaseModeRusi4()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        protected Double GetCurrent(KeyValuePair<Double, VFI> pair)
        {
            return (pair.Value.CurrentMax + pair.Value.CurrentMin) / 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        protected Double GetForce(KeyValuePair<Double, VFI> pair)
        {
            return (pair.Value.ForceMax + pair.Value.ForceMin) / 2;
        }

        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="InvalidOperationException">Ни один элемент не удовлетворяет условию предиката <paramref name="predicate" />.– или –Исходная последовательность пуста.</exception>
        private Tuple<Double, Double> GetForceAndCurrent(Double velocity)
        {
            try
            {
                var vfi1 = vfi.Last(v => v.Key <= velocity);
                var vfi2 = vfi.First(v => v.Key >= velocity);

                var v1 = vfi1.Key;
                var v2 = vfi2.Key;

                var f1 = GetForce(vfi1);
                var f2 = GetForce(vfi2);

                var c1 = GetCurrent(vfi1);
                var c2 = GetCurrent(vfi2);

                var k1 = 0.0;
                var k2 = 0.0;
                

                //только при скорости 0 MathHelper.IsEqual(vfi1.Key, vfi2.Key)!!! если будет выше 85 - УПАДЕМ!!!

                if (!MathHelper.IsEqual(vfi1.Key, vfi2.Key))
                {
                    k1 = GetK(v1, v2, f1, f2);
                    
                    k2 = GetK(v1, v2, c1, c2);
                    
                }

                var force = k1 * velocity + GetB(v1, k1, f1);
                var current = k2 * velocity + GetB(v1, k2, c1);

                if (current < 0)
                    force = -force;
                return new Tuple<Double, Double>(force, current);
            }
            catch
            {
                throw new ArgumentOutOfRangeException(nameof(velocity));
            }
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
        public virtual Double GetForce(Double velocity)
        {
            return GetForceAndCurrent(velocity).Item1;
        }

        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="InvalidOperationException">Ни один элемент не удовлетворяет условию предиката <paramref name="predicate" />.– или –Исходная последовательность пуста.</exception>
        public virtual Double GetCurrent(Double velocity)
        {
            return GetForceAndCurrent(velocity).Item2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Double GetBaseResistance(BaseTrain train)
        {
            var tara = train.UnladenWeight;
            var massa = train.Mass;
            var velocity = Converter.GetVelocityKmPerHour(train.Velocity);
            var openFactor = train.FactorOfOpenStage;
            return GetBaseResistanceRusi4(tara, massa, velocity, openFactor);
        }

        /// <summary>
        /// Переход на низкий уровень Тяга-> Выбег ->Тормоз
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public abstract IModeControl Low(MassMass mass);

        /// <summary>
        /// Переход из торможения в выбег
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public abstract IModeControl High(MassMass mass);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tara"></param>
        /// <param name="massa"></param>
        /// <param name="velocity"></param>
        /// <param name="openFactor"></param>
        /// <returns></returns>
        private static Double GetBaseResistanceRusi4(Double tara, Double massa, Double velocity, Double openFactor)
        {
            const Double coefficient1 = 1.1;
            const Double coefficient2 = 0.01;
            const Double coefficient3 = 0.001;

            var trainWeightFactor = tara / (tara + massa);

            return coefficient1 * trainWeightFactor
                + coefficient2 * velocity
                + coefficient3 * trainWeightFactor * velocity * velocity * openFactor;
        }
    }
}
