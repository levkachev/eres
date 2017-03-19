using System;

namespace TrainMovement.PhisicaHelper
{
    internal sealed class Range
    {
        public Double Left { get; }

        public Double Right { get; }

        public Range(Double left, Double right)
        {
            if (right < left)
                throw new ArgumentException("Right bound must be greater or equal then left bound.");

            Left = left;
            Right = right;
        }

        public Boolean IsPoint()
        {
            return Math.Abs(Left - Right) < Double.Epsilon;
        }

        public Boolean Contains(Double value)
        {
            return Left <= value && value <= Right;
        }
    }
}

