using System;

namespace TrainMovement.PhisicalHelper
{
    /// <summary>
    /// 
    /// </summary>
    public static class Converter
    {
        private const Double g = 9.81;

        private const Double k = 1000;

        private const Double secPerHour = 3600;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocityMeterPerSec"></param>
        /// <returns></returns>

        public static Double GetVelocityKmPerHour(Double velocityMeterPerSec)
        {
            return velocityMeterPerSec * secPerHour / k;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocityPerKmPerHour"></param>
        /// <returns></returns>
        public static Double GetVelocityMeterPerSec(Double velocityPerKmPerHour)
        {
            return velocityPerKmPerHour * k / secPerHour;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kgForce"></param>
        /// <returns></returns>

        public static Double GetForceInKNewton(Double kgForce)
        {
            return kgForce * k / g;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="forceNewton"></param>
        /// <returns></returns>
        public static Double GetForceH(Double forceNewton)
        {
            return forceNewton * g / k;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Double GetFactor()
        {
            return g*secPerHour/(k*k);
        }

        /// <summary>
        /// Перевод в килоСилу
        /// </summary>
        /// <param name="force"></param>
        /// <returns></returns>
        public static Double GetForceInK(Double force)
        {
            return force * k;
        }
    }
}

