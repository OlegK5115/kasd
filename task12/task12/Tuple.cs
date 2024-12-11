using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12
{
    struct Tuple
    {
        public double time;
        public int priority;
        public int number;
        public int step;
        public Tuple(double time, int priority, int number, int step)
        {
            this.time = time;
            this.priority = priority;
            this.number = number;
            this.step = step;
        }
    }
}
