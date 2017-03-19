using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
