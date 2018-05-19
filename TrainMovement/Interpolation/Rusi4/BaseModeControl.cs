using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ORM.OldHelpers;
using ORM.Trains.Entities;
using ORM.Trains.Interpolation.Entities;
using TrainMovement.ModeControl;
using TrainMovement.Stuff;
using TrainMovement.Train;

namespace TrainMovement.Interpolation.Rusi4
{ 
    /// <inheritdoc />
    /// <summary>
    /// Базовый класс для режимов ведения ЭПС 81-740.1 ("Русич")
    /// </summary>
    public abstract class BaseModeControl : IModeControl
    {
        /// <summary>
        /// 
        /// </summary>
        public Mass Mass;// { get; protected set; }

        /// <summary>
        ///
        /// </summary>
        private static readonly Dictionary<Type, BaseModeControl> instances = new Dictionary<Type, BaseModeControl>();

        /// <summary>
        ///
        /// </summary>
        /// <exception cref="InvalidOperationException">Condition.</exception>
        protected static T GetInstance<T>(Mass characteristics) where T: BaseModeControl
        {
            if (instances.TryGetValue(typeof(T), out var modeControl))
                return modeControl as T;

            var constructor = typeof(T).GetConstructor(
                bindingAttr : BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                binder : null,
                types : new[] { typeof(Mass) },
                modifiers : null);
            if (constructor == null)
                throw new InvalidOperationException();

            modeControl = constructor.Invoke(new Object[] { characteristics }) as BaseModeControl;
            instances.Add(typeof(T), modeControl);
            return modeControl as T;
        }

        /// <summary>
        /// Характеристики
        /// </summary>
        protected SortedList<Double, ElectricTractionCharacteristics> Characteristics;

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        public IEnumerable<ElectricTractionCharacteristics> ForceAndCurrent
        {
            get => Characteristics.Values;
            protected set => Characteristics = SetForceAndCurrent(value);
        }

        /// <summary>
        /// Преобразование в SortedList по скорости
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        private static SortedList<Double, ElectricTractionCharacteristics> SetForceAndCurrent(IEnumerable<ElectricTractionCharacteristics> characteristics) =>
            characteristics.ToSortedList(item => item.Velocity);

        /// <summary>
        /// 
        /// </summary>
        protected BaseModeControl() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        protected Double GetCurrent(KeyValuePair<Double, ElectricTractionCharacteristics> pair) =>
            (pair.Value.CurrentMax + pair.Value.CurrentMin) / 2;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        protected Double GetForce(KeyValuePair<Double, ElectricTractionCharacteristics> pair) => 
            (pair.Value.ForceMax + pair.Value.ForceMin) / 2;

        /// <inheritdoc cref="BaseModeControl" />
        /// <summary>
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        public abstract Double GetForce(Double velocity, BaseTrain train);

        /// <summary>
        ///
        /// </summary>
        /// <inheritdoc />
        /// <exception cref="T:System.ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="T:System.InvalidOperationException">Ни один элемент не удовлетворяет условию предиката <paramref name="predicate" />.– или – Исходная последовательность пуста.</exception>
        public virtual Double GetCurrent(Double velocity, BaseTrain train) =>
            GetForceAndCurrent(velocity, train.Mass).Current;

        /// <summary>
        ///
        /// </summary>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="InvalidOperationException">Ни один элемент не удовлетворяет условию предиката <paramref name="predicate" />.– или –Исходная последовательность пуста.</exception>
        protected virtual (Double Force, Double Current) GetForceAndCurrent(Double velocity, Double mass)
        {
            try
            {
                var vfi1 = Characteristics.Last(v => v.Key <= velocity);
                var vfi2 = Characteristics.First(v => v.Key >= velocity);

                var v1 = vfi1.Key;
                var v2 = vfi2.Key;

                var f1 = GetForce(vfi1);
                var f2 = GetForce(vfi2);

                var c1 = GetCurrent(vfi1);
                var c2 = GetCurrent(vfi2);

                //const Double maxMass = 18.5;
                //var force   = (f2 - f1) / maxMass * mass + f1;
                //var current = (c2 - c1) / maxMass * mass + c1;

                var k1 = 0.0;
                var k2 = 0.0;

                //WARNING только при скорости 0 MathHelper.IsEqual(vfi1.Key, vfi2.Key)!!! если будет выше 85 - УПАДЕМ!!!
                if (!vfi1.Key.IsEqual(vfi2.Key))
                {
                    k1 = MathHelper.GetK(v1, v2, f1, f2);
                    k2 = MathHelper.GetK(v1, v2, c1, c2);
                }

                var force = k1 * velocity + MathHelper.GetB(v1, k1, f1);
                var current = k2 * velocity + MathHelper.GetB(v1, k2, c1);

                //if (current < 0)
                //    force = -force;

                return (force, current);
            }
            catch
            {
                throw new ArgumentOutOfRangeException(nameof(velocity));
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public virtual Double GetEfficiency(Double velocity)
        {
            var efficiency = (15370 * velocity - 161) / (Math.Pow(velocity, 3) - 70.71 * Math.Pow(velocity, 2) + 14180);
            if (efficiency < 0)
                efficiency = 0;
            else if (efficiency > 1)
                efficiency = 1;
            return efficiency;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public Double GetBaseResistance(BaseTrain train)
        {
            var tara = train.UnladenWeight;
            var mass = train.Mass;
            var velocity = train.Velocity;
            var openFactor = train.FactorOfOpenStage;
            return GetBaseResistance(tara, mass, velocity, openFactor);
        }

        /// <summary>
        /// Расчет основного сопротивления для Русич для всех режимов одинаков (Мелешин ИС)
        /// </summary>
        /// <param name="tara">Масса вагона(?), т.</param>
        /// <param name="mass">Масса пассажиров, т.</param>
        /// <param name="velocity">Скорость, км/ч.</param>
        /// <param name="openFactor">Открытый/закрытый участок линии (зависит от перегона).</param>
        /// <returns></returns>
        private static Double GetBaseResistance(Double tara, Double mass, Double velocity, Double openFactor)
        {
            const Double coefficient1 = 1.1;
            const Double coefficient2 = 0.01;
            const Double coefficient3 = 0.001;

            var trainWeightFactor = tara / (tara + mass);

            return coefficient1 * trainWeightFactor
                   + coefficient2 * velocity
                   + coefficient3 * trainWeightFactor * velocity * velocity * openFactor;
        }

        /// <inheritdoc />
        /// <summary>
        /// Переход на низкий уровень Тяга --> Выбег --> Тормоз
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public abstract IModeControl Low(Mass characteristics);

        /// <inheritdoc />
        /// <summary>
        /// Переход из торможения в выбег
        /// </summary>
        /// <param name="characteristics"></param>
        /// <returns></returns>
        public abstract IModeControl High(Mass characteristics);

        /// <summary>
        /// Возвращает название данного вида управления
        /// </summary>
        /// <returns></returns>
        public override String ToString() => GetType().Name;
    }
}
