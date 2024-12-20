using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task19
{
    class Pair<T1, T2>
    {
        public T1 key;
        public T2 value;
        public Pair(T1 key, T2 value)
        {
            this.key = key;
            this.value = value;
        }
        public override string ToString()
        {
            return $"|{key}, {value}|";
        }
    }
}
