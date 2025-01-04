using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task28
{
    public interface IMySortedMap<K, V> : IMyMap<K, V>
    {
        K FirstKey();
        K LastKey();
        IMySortedMap<K, V> HeadMap(K end);
        IMySortedMap<K, V> SubMap(K start, K end);
        IMySortedMap<K, V> TailMap(K start);
    }
}
