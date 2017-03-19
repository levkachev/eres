using System;
using System.Collections.Generic;

namespace TrainMovement.PhisicaHelper
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
                {"current", new Range(-2000, 2000)},
                {"mass", new Range(0, 20)},
                {"velocity", new Range(0, 200)},
                {"voltage", new Range(400, 900)},
                {"time", new Range(0, 36000)},
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
    }
}

