using System;

namespace Helpers.Math
{
    public sealed class FunctionSegment : IComparable<FunctionSegment>, IEquatable<FunctionSegment>
    {
        public Range Range { get; }

        public Func<Double, Double> Function { get; }

        public FunctionSegment(Range range, Func<Double, Double> function)
        {
            Range = range;
            Function = function ?? throw new ArgumentNullException(nameof(function));
        }

        public Int32 CompareTo(FunctionSegment other) => other is null ? 1 : Range.CompareTo(other.Range);

        public Boolean Equals(FunctionSegment other) => other is null || Range.Equals(other.Range);
    }
}