using System;

namespace ORM.OldHelpers
{
    /// <summary>
    /// Вспомогательные математические функции.
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Возвращает истина, если два значения равны с некоторой точностью. Если третий парамер (точность) не указан, то используется значение по умолчанию (<see cref="Double.Epsilon"/>).
        /// </summary>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static Boolean IsEqual(this Double arg0, Double arg1, Double tolerance = Double.Epsilon) => Math.Abs(arg0 - arg1) < tolerance;

        /// <summary>
        /// Проверка на эквивалентность (с заданной точностью) значения нулю.  Если второй парамер (точность) не указан, то используется значение по умолчанию (<see cref="Double.Epsilon"/>).
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static Boolean IsZero(this Double value, Double tolerance = Double.Epsilon) => Math.Abs(value) < tolerance;

        /// <summary>
        /// Проверка попадает ли значение в указанный диапазон (включительно)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Boolean IsIntoRange(this Double value, Double from = Double.NegativeInfinity, Double to = Double.PositiveInfinity) => from <= value && value <= to;

        /// <summary>
        /// Замена отрицательного значения нулём.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Double ToNonNegativeValue(this Double value) => value < 0 ? 0 : value;

        /// <summary>
        /// Коэффициент наклона относительно оси абсцисс (k) прямой (y = kx + b).
        /// </summary>
        /// <param name="x1">Абсцисса первой точки.</param>
        /// <param name="x2">Абсцисса второй точки.</param>
        /// <param name="y1">Ордината первой точки.</param>
        /// <param name="y2">Ордината второй точки.</param>
        /// <returns></returns>
        public static Double GetK(Double x1, Double x2, Double y1, Double y2) => (y1 - y2) / (x1 - x2);

        /// <summary>
        /// Коэффициент смещения вдоль оси ординат (b) прямой (y = kx + b).
        /// </summary>
        /// <param name="x">Абсцисса точки.</param>
        /// <param name="k">Коэффициент наклона прямой.</param>
        /// <param name="y">Ордината точки.</param>
        /// <returns></returns>
        public static Double GetB(Double x, Double k, Double y) => y - k * x;
    }
}