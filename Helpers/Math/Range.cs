using System;
using System.Globalization;
using static System.Math;

namespace Helpers.Math
{
    /// <inheritdoc />
    /// <summary>
    /// Диапазон вещественных значений.
    /// </summary>
    public struct Range : IComparable<Range>, IEquatable<Range>, IFormattable
    {
        /// <summary>
        /// Начало диапазона.
        /// </summary>
        public Double From { get; }

        /// <summary>
        /// Конец диапазона.
        /// </summary>
        public Double To { get; }

        /// <summary>
        /// Конструктор, создающий диапазон, ограниченный указанными пределами.
        /// </summary>
        /// <param name="from">Начало диапазона (по умолчанию <see cref="Double.NegativeInfinity"/>).</param>
        /// <param name="to">Конец диапазона (по умолчанию <see cref="Double.PositiveInfinity"/>).</param>
        /// <exception cref="ArgumentException"/>
        public Range(Double from = Double.NegativeInfinity, Double to = Double.PositiveInfinity)
        {
            if (to < from)
                throw new ArgumentException("Right bound must be greater then left.");

            From = from;
            To = to;
        }

        /// <summary>
        /// Метод, проверяющий попадает ли значение (<paramref name="value"/>) в данный диапазон.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <returns>Возвращает <see langword="true"/>, если попадает, <see langword="false"/> -- в противном случае.</returns>
        public Boolean Contains(Double value) => From <= value && value <= To;

        /// <summary>
        ///  Свойство, указывающее является ли данный диапазон точкой (<see cref="From"/> совпадает с <see cref="To"/>).
        /// </summary>
        public Boolean IsPoint => Abs(From - To) <= Double.Epsilon;

        public Int32 CompareTo(Range other) => From.CompareTo(other.From);

        public Boolean Equals(Range other) => From.IsEqual(other.From) && To.IsEqual(other.To);

        public override String ToString() => $"[{From}; {To}]";

        public String ToString(String format) => ToString(format, CultureInfo.CurrentCulture.NumberFormat);

        public String ToString(String format, IFormatProvider formatProvider) => 
            $"[{From.ToString(format, formatProvider)}; {To.ToString(format, formatProvider)}]";
    }
}