using System;

namespace Helpers.Math
{
    public struct Point : IComparable<Point>, IComparable, IEquatable<Point>
    {
        /// <summary>
        /// Abscissa
        /// </summary>
        public Double X { get; }

        /// <summary>
        /// Ordinate
        /// </summary>
        public Double Y { get; }

        /// <summary>
        /// Construct point by abscissa (<paramref name="x"/>) and ordinate (<paramref name="y"/>).
        /// </summary>
        /// <param name="x">Abscissa</param>
        /// <param name="y">Ordinate</param>
        public Point(Double x, Double y)
        {
            X = x;
            Y = y;
        }

        public Int32 CompareTo(Point other)
        {
            if (X < other.X) return -1;
            if (X > other.X) return +1;
            return 0;
        }

        public Int32 CompareTo(Object obj)
        {
            if (obj is null) return 1;
            if (!(obj is Point)) throw new ArgumentException($"Object must be of type {nameof(Point)}");
            return CompareTo((Point) obj);
        }

        public static Boolean operator <(Point left, Point right)
        {
            return left.CompareTo(right) < 0;
        }

        public static Boolean operator >(Point left, Point right)
        {
            return left.CompareTo(right) > 0;
        }

        public static Boolean operator <=(Point left, Point right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static Boolean operator >=(Point left, Point right)
        {
            return left.CompareTo(right) >= 0;
        }

        public Boolean Equals(Point other)
        {
            return X.Equals(other.X);
        }

        public override String ToString()
        {
            return $"{{{X}; {Y}}}";
        }

        public override Boolean Equals(Object obj)
        {
            if (obj is null) return false;
            return obj is Point point && Equals(point);
        }

        public override Int32 GetHashCode()
        {
            return X.GetHashCode();
        }
    }
}