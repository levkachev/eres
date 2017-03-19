using System;
using System.Collections.Generic;

namespace ORM.Train.Entities
{
    public class TrainType
    {
        public virtual IEnumerable<String> TrainTypes { get; set; }

        public TrainType()
        {
            TrainTypes = new List<String>();
        }
    }
}
