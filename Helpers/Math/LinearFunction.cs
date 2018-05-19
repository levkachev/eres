using System;

namespace Helpers.Math
{
    public sealed class LinearFunction
    {
        #region Properties

        /// <summary>
        /// Left point
        /// </summary>
        public Point Left { get; }

        /// <summary>
        /// Right point
        /// </summary>
        public Point Right { get; }

        /// <summary>
        /// Slope factor
        /// </summary>
        public Double K { get; }

        /// <summary>
        /// Intercept factor
        /// </summary>
        public Double B { get; }

        /// <summary>
        /// Function
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public Func<Double, Double> Function
        {
            get
            {
                // lambda can not use this properties
                var k = K;
                var b = B;
                return x =>
                {
                    if (Left.X <= x && x <= Right.X)
                        return k * x + b;
                    throw new ArgumentOutOfRangeException(nameof(x));
                };
            }
        }

        #endregion

        #region Constructors

        public LinearFunction(Point left, Point right)
        {
            if (right < left)
                throw new ArgumentException("Right point must has abscissa value greater then left point.");

            Left = left;
            Right = right;

            K = (Left.Y - Right.Y) / (Left.X - Right.X);
            B =  Left.Y - K * Left.X;
        }

        public LinearFunction(Double x1, Double y1, Double x2, Double y2)
        {
            if (x1 < x2)
                throw new ArgumentException("Right point must has abscissa value greater then left point.");

            Left = new Point(x1, y1);
            Right = new Point(x2, y2);

            K = (Left.Y - Right.Y) / (Left.X - Right.X);
            B =  Left.Y - K * Left.X;
        }

        #endregion

        #region Methods

        public override String ToString() => $"[{Left.X}; {Right.X}] ---> y(x) = {K} * x + {B}";

        #endregion
    }
}
