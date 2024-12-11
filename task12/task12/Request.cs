using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12
{
    struct Request : IComparable<Request>
    {
        public int priority;
        public int number;
        public int step;
        public Request(int priority, int number, int step)
        {
            this.priority = priority;
            this.number = number;
            this.step = step;
        }
        public int CompareTo(Request req)
        {
            return priority - req.priority;
        }
    }
}
