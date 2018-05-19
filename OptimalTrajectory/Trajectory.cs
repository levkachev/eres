using System;
using System.Collections;
using System.Collections.Generic;

namespace OptimalTrajectory
{
    public class Trajectory : IEnumerable<Segment>
    {
        private IEnumerable<Step> steps = new Queue<Step>();

        private Queue<Segment> segments = new Queue<Segment>();

        public IEnumerator<Segment> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
