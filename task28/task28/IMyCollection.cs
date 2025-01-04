using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task28
{
    public interface IMyCollection<T>
    {
        void Add(T e);
        void AddAll(T[] a);
        void Clear();
        bool Contains(object o);
        bool ContainsAll(IMyCollection<T> c);
        bool IsEmpty();
        void Remove(object obj);
        void RemoveAll(IMyCollection<T> a);
        void RetainAll(IMyCollection<T> a);
        int Size();
        T[] ToArray();
        T[] ToArray(ref T[] a);
    }
}
