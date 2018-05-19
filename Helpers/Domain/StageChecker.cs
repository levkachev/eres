using System;
using System.Collections.Generic;
using Helpers.Math;

namespace Helpers.Domain
{
    public sealed class StageChecker : ConstraintsChecker
    {
        private StageChecker()
        {
            Constraints = new Dictionary<String, Range>
            {
                { "Length", new Range(from: 0) },
            };
        }

        public Boolean CheckLength(Double length) => CheckConstraint("Length", length);
    }
}