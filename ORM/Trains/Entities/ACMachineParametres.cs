using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Train.Entities
{
    public class ACMachineParametres : MachineBaseParametres
    {
        private Double umax;

        public Double Umax
        {
            get { return umax; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                umax = value;
            }
        }
    }
}
