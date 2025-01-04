using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task28
{
    public interface IMyMap<K, V>
    {
        void Clear();
        bool ContainsKey(object key);
        bool ContainsValue(object value);
        IEnumerable<KeyValuePair<K, V>> EntrySet();
        V Get(object key);
        bool IsEmpty();
        List<K> KeySet();
        void Put(K key, V value);
        void PutAll(IMyMap<K, V> m);
        bool Remove(object key);
        int Size();
        IMyCollection<V> Values();
    }
}
