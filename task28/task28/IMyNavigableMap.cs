using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task28
{
    public interface IMyNavigableMap<K, V> : IMySortedMap<K, V>
    {
        KeyValuePair<K, V> LowerEntry(K key);
        KeyValuePair<K, V> FloorEntry(K key);
        KeyValuePair<K, V> HigherEntry(K key);
        KeyValuePair<K, V> CeilingEntry(K key);
        K LowerKey(K key);
        K FloorKey(K key);
        K HigherKey(K key);
        K CeilingKey(K key);
        KeyValuePair<K, V> PollFirstEntry();
        KeyValuePair<K, V> PollLastEntry();
        V FirstEntry();
        V LastEntry();
    }
}
