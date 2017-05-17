using System;
using System.Collections.Generic;

namespace TrainMovement.PhisicalHelper
{
    /// <summary>
    /// Maximal and Minimum limits
    /// </summary>
    internal static class DomainHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<String, Range> Constraints;

        static DomainHelper()
        {
            Constraints = new Dictionary<String, Range>
            {
                {"acceleration", new Range(-10, 10)},
                {"carLength", new Range(0, 200)},
                {"current", new Range(-10000, 10000)},
                {"mass", new Range(0, 200)},
                {"velocity", new Range(-10, 200)},
                {"voltage", new Range(400, 900)},
                {"time", new Range(0, 36000)},
                {"space", new Range(0,5000) },

                 {"unladenWeight", new Range(20,60)},
                 {"ownNeedsElectricPower", new Range(0,50)},
                 {"netResistancePullFactor", new Range(0,1)},
                 {"aerodynamicDragFactor", new Range(0,0.1)},
                 {"netResistenceCoastingFactor1", new Range(0,1)},
                 {"netResistenceCoastingFactor2", new Range(0,1)},
                 {"netResistenceCoastingFactor3", new Range(0,1)},
                 {"trainEquivalentSurface", new Range(0,250)},
                 {"inertiaRotationFactor", new Range(0,0.1)},
                 {"numberCars", new Range(1,8)},
                 {"breakAverage", new Range(0,0.9)},
                
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
            if (!Constraints.ContainsKey(key))
                throw new ArgumentOutOfRangeException(nameof(key));

            return Constraints[key].Contains(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acceleration"></param>
        /// <returns></returns>
        public static Boolean CheckAcceleration(Double acceleration)
        {
            return CheckConstraint("acceleration", acceleration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static Boolean CheckCurrent(Double current)
        {
            return CheckConstraint("current", current);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Boolean CheckMass(Double mass)
        {
            return CheckConstraint("mass", mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public static Boolean CheckVelocity(Double velocity)
        {
            return CheckConstraint("velocity", velocity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voltage"></param>
        /// <returns></returns>
        public static Boolean CheckVoltage(Double voltage)
        {
            return CheckConstraint("voltage", voltage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        public static Boolean CheckSpace(Double space)
        {
            return CheckConstraint("space", space);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckCarLength(Double carLength)
        {
            return CheckConstraint("carLength", carLength);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckUnladenWeight(Double unladenWeight)
        {
            return CheckConstraint("unladenWeight", unladenWeight);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckOwnNeedsElectricPower(Double ownNeedsElectricPower)
        {
            return CheckConstraint("ownNeedsElectricPower", ownNeedsElectricPower);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckNetResistancePullFactor(Double netResistancePullFactor)
        {
            return CheckConstraint("netResistancePullFactor", netResistancePullFactor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckAerodynamicDragFactor(Double aerodynamicDragFactor)
        {
            return CheckConstraint("aerodynamicDragFactor", aerodynamicDragFactor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckNetResistanceCoastingFactor1(Double netResistanceCoastingFactor1)
        {
            return CheckConstraint("netResistenceCoastingFactor1", netResistanceCoastingFactor1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckNetResistanceCoastingFactor2(Double netResistanceCoastingFactor2)
        {
            return CheckConstraint("netResistenceCoastingFactor2", netResistanceCoastingFactor2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckNetResistanceCoastingFactor3(Double netResistanceCoastingFactor3)
        {
            return CheckConstraint("netResistenceCoastingFactor3", netResistanceCoastingFactor3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckTrainEquivalentSurface(Double trainEquivalentSurface)
        {
            return CheckConstraint("trainEquivalentSurface", trainEquivalentSurface);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckInertiaRotationFactor(Double inertiaRotationFactor)
        {
            return CheckConstraint("inertiaRotationFactor", inertiaRotationFactor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckTime(Double time)
        {
            return CheckConstraint("time", time);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckNumberCars(Double numberCars)
        {
            return CheckConstraint("numberCars", numberCars);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="carLength"></param>
        /// <returns></returns>
        public static Boolean CheckBreakAverage(Double breakAverage)
        {
            return CheckConstraint("breakAverage", breakAverage);
        }
    }
}
