using System;
using System.Collections.Generic;
using Helpers.Math;

namespace Helpers.Domain
{
    /// <inheritdoc />
    public sealed class TrainChecker : ConstraintsChecker
    {
        private TrainChecker()
        {
            Constraints = new Dictionary<String, Range>
            {
                {"acceleration", new Range(-10, 10)},
                {"carLength", new Range(0, 200)},
                {"current", new Range(-20000, 20000)},
                {"mass", new Range(0, 200)},
                {"velocity", new Range(-10, 200)},
                {"voltage", new Range(400, 950)},
                {"time", new Range(0, 36000)},
                {"space", new Range(0, 5000)},

                {"unladenWeight", new Range(20, 60)},
                {"ownNeedsElectricPower", new Range(0, 50)},
                {"netResistancePullFactor", new Range(0, 1)},
                {"aerodynamicDragFactor", new Range(0, 0.1)},
                {"netResistenceCoastingFactor1", new Range(0, 1)},
                {"netResistenceCoastingFactor2", new Range(0, 1)},
                {"netResistenceCoastingFactor3", new Range(0, 1)},
                {"trainEquivalentSurface", new Range(0, 250)},
                {"inertiaRotationFactor", new Range(0, 0.1)},
                {"numberCars", new Range(1, 8)},
                {"breakAverage", new Range(0, 0.9)},

                {"A", new Range(from: 0) },

            };
        }

        private static readonly Lazy<TrainChecker> instance = new Lazy<TrainChecker>(() => new TrainChecker());

        public static TrainChecker GetInstance() => instance.Value;
    }
}