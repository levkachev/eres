using System;
using System.Collections.Generic;

namespace Helpers.Math
{
    public sealed class PiecewiseFunction
    {
        private readonly LinkedList<FunctionSegment> functions = new LinkedList<FunctionSegment>();

        public PiecewiseFunction(IEnumerable<FunctionSegment> segments)
        {
            var sortedBuffer = new SortedSet<FunctionSegment>(segments);
            foreach (var segment in sortedBuffer)
                functions.AddLast(segment);
        }

        public FunctionSegment this[Double abscissa]
        {
            get
            {
                var current = functions.First ?? throw new InvalidOperationException("Functions list is empty.");
                while (current?.Value.Range.Contains(abscissa) ?? false)
                    current = current.Next;
                return current?.Value ?? functions.Last.Value;
            }
        }
    }
}
