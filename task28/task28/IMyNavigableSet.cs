using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task28
{
    public interface IMyNavigableSet<K> : IMySortedSet<K>
    {
        K LowerEntry(K key);
        K FloorEntry(K key);
        K HigherEntry(K key);
        K CeilingEntry(K key);
        K LowerKey(K key);
        K FloorKey(K key);
        K HigherKey(K key);
        K CeilingKey(K key);
        K PollFirstEntry();
        K PollLastEntry();
        int FirstEntry();
        int LastEntry();
    }
}
