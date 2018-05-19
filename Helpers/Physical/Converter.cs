using System;

namespace Helpers.Physical
{
    /// <summary>
    /// 
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Ускорение свободного падения м/с^2
        /// </summary>
        private const Double g = 9.81;

        /// <summary>
        /// Приставка "кило-" (1000)
        /// </summary>
        private const Double k = 1e3;

        /// <summary>
        /// Приставка "мега-" (1000000)
        /// </summary>
        private const Double M = 1e6;

        /// <summary>
        /// Число секунд в одном часе
        /// </summary>
        private const Double secPerHour = 3600;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocityMeterPerSec"></param>
        /// <returns></returns>
        public static Double GetVelocityKmPerHour(Double velocityMeterPerSec) => velocityMeterPerSec * secPerHour / k;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocityPerKmPerHour"></param>
        /// <returns></returns>
        public static Double GetVelocityMeterPerSec(Double velocityPerKmPerHour) => velocityPerKmPerHour * k / secPerHour;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kgForce"></param>
        /// <returns></returns>
        public static Double GetForceInKNewton(Double kgForce) => kgForce * k / g;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forceNewton"></param>
        /// <returns></returns>
        public static Double GetForceH(Double forceNewton) => forceNewton * g / k;

        /// <summary>
        /// 
        /// </summary>
        public static Double GetFactor() => g * secPerHour / (k * k);

        /// <summary>
        /// Перевод в килоСилу
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Double GetInKilo(Double value) => value * k;
    }
}

