using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task28
{
    public interface IMyIterator<T>
    {
        bool HasNext();
        T Next();
        void Remove();
    }

}
