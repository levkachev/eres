using System;
using System.Collections.Generic;
using Helpers.Math;

namespace Helpers.Domain
{
    public class ConstraintsChecker
    {
        protected Dictionary<String, Range> Constraints;

        protected ConstraintsChecker() {}

        protected Boolean CheckConstraint(String key, Double value) => Constraints[key].Contains(value);

        protected static T GetInstance<T>() where T : ConstraintsChecker => throw new NotImplementedException();
    }
}
