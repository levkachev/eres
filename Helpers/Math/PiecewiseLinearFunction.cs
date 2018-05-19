using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers.Math
{
    public sealed class PiecewiseLinearFunction
    {
        private readonly LinkedList<LinearFunction> functions = new LinkedList<LinearFunction>();

        public PiecewiseLinearFunction(IEnumerable<Point> points)
        {
            if (points is null)
                throw new ArgumentNullException(nameof(points));

            var tmp = new SortedSet<Point>(points).ToArray();
            for (var i = 0; i < tmp.Length - 1; ++i)
                functions.AddLast(new LinearFunction(tmp[i], tmp[i + 1]));
        }

        public LinearFunction this[Double abscissa]
        {
            get
            {
                var previous = functions.First;
                if (previous is null)
                    throw new InvalidOperationException("Functions list is empty.");

                var current = previous.Next;
                while (current?.Value?.Left.X < abscissa)
                {
                    previous = current;
                    current = current.Next;
                }

                return previous.Value;
            }
        }
    }
}