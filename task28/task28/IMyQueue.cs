using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task28
{
    public interface IMyQueue<T> : IMyCollection<T>
    {
        T Element();
        bool Offer(T obj);
        T Peek();
        T Poll();
    }
}
