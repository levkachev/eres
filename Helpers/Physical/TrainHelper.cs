using System;
using System.Collections.Generic;
using Helpers.Math;

namespace Helpers.Physical
{
    /// <summary>
    /// Помощник, проверяющий ограничения, формируемые предметной областью электроподвижного состава (ЭПС).
    /// </summary>
    public static class TrainHelper
    {
        /// <summary>
        /// Ограничения
        /// </summary>
        private static readonly Dictionary<String, Range> constraints;

        static TrainHelper()
        {
            constraints = new Dictionary<String, Range>
            {
                {"acceleration", new Range(-10, 10)},
                {"carLength", new Range(0, 200)},
                {"current", new Range(-20000, 20000)},
                {"mass", new Range(0, 200)},
                {"velocity", new Range(-10, 200)},
                {"voltage", new Range(400, 950)},
                {"time", new Range(0, 36000)},
                {"space", new Range(0, 5000)},

                {"unladenWeight", new Range(20, 60)},
                {"ownNeedsElectricPower", new Range(0, 50)},
                {"netResistancePullFactor", new Range(0, 1)},
                {"aerodynamicDragFactor", new Range(0, 0.1)},
                {"netResistenceCoastingFactor1", new Range(0, 1)},
                {"netResistenceCoastingFactor2", new Range(0, 1)},
                {"netResistenceCoastingFactor3", new Range(0, 1)},
                {"trainEquivalentSurface", new Range(0, 250)},
                {"inertiaRotationFactor", new Range(0, 0.1)},
                {"numberCars", new Range(1, 8)},
                {"breakAverage", new Range(0, 0.9)},

                {"A", new Range(from: 0) },
                
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Boolean CheckConstraint(String key, Double value)
        {
            if (!constraints.ContainsKey(key))
                throw new ArgumentOutOfRangeException(nameof(key));

            return constraints[key].Contains(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acceleration"></param>
        /// <returns></returns>
        public static Boolean CheckAcceleration(Double acceleration) => CheckConstraint("acceleration", acceleration);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static Boolean CheckCurrent(Double current) => CheckConstraint("current", current);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Boolean CheckMass(Double mass) => CheckConstraint("mass", mass);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public static Boolean CheckVelocity(Double velocity) => CheckConstraint("velocity", velocity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voltage"></param>
        /// <returns></returns>
        public static Boolean CheckVoltage(Double voltage) => CheckConstraint("voltage", voltage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        public static Boolean CheckSpace(Double space) => CheckConstraint("space", space);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckCarLength(Double carLength) => CheckConstraint("carLength", carLength);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unladenWeight"></param>
        /// <returns></returns>
        public static Boolean CheckUnladenWeight(Double unladenWeight) => CheckConstraint("unladenWeight", unladenWeight);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownNeedsElectricPower"></param>
        /// <returns></returns>
        public static Boolean CheckOwnNeedsElectricPower(Double ownNeedsElectricPower) => CheckConstraint("ownNeedsElectricPower", ownNeedsElectricPower);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netResistancePullFactor"></param>
        /// <returns></returns>
        public static Boolean CheckNetResistancePullFactor(Double netResistancePullFactor) => CheckConstraint("netResistancePullFactor", netResistancePullFactor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aerodynamicDragFactor"></param>
        /// <returns></returns>
        public static Boolean CheckAerodynamicDragFactor(Double aerodynamicDragFactor) => CheckConstraint("aerodynamicDragFactor", aerodynamicDragFactor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netResistanceCoastingFactor1"></param>
        /// <returns></returns>
        public static Boolean CheckNetResistanceCoastingFactor1(Double netResistanceCoastingFactor1) => CheckConstraint("netResistenceCoastingFactor1", netResistanceCoastingFactor1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netResistanceCoastingFactor2"></param>
        /// <returns></returns>
        public static Boolean CheckNetResistanceCoastingFactor2(Double netResistanceCoastingFactor2) => CheckConstraint("netResistenceCoastingFactor2", netResistanceCoastingFactor2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="netResistanceCoastingFactor3"></param>
        /// <returns></returns>
        public static Boolean CheckNetResistanceCoastingFactor3(Double netResistanceCoastingFactor3) => CheckConstraint("netResistenceCoastingFactor3", netResistanceCoastingFactor3);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainEquivalentSurface"></param>
        /// <returns></returns>
        public static Boolean CheckTrainEquivalentSurface(Double trainEquivalentSurface) => CheckConstraint("trainEquivalentSurface", trainEquivalentSurface);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Boolean CheckInertiaRotationFactor(Double inertiaRotationFactor) => CheckConstraint("inertiaRotationFactor", inertiaRotationFactor);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Boolean CheckTime(Double time) => CheckConstraint("time", time);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberCars"></param>
        /// <returns></returns>
        public static Boolean CheckNumberCars(Double numberCars) => CheckConstraint("numberCars", numberCars);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="breakAverage"></param>
        /// <returns></returns>
        public static Boolean CheckBreakAverage(Double breakAverage) => CheckConstraint("breakAverage", breakAverage);

        /// <summary>
        /// Проверка значения расхода энергии
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Boolean CheckEnergyConsumption(Double a) => CheckConstraint("A", a);

        /// <summary>
        /// Проверка названия модели электроподвижного состава (ЭПС).
        /// </summary>
        /// <param name="name">Название модели ЭПС.</param>
        /// <returns></returns>
        public static Boolean CheckName(String name) => !(String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name));
    }
}
