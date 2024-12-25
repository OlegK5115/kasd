using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task27
{
    public interface MyIterator<T>
    {
        bool HasNext();
        T Next();
        void Remove();
    }

    public interface MyIterator_ext<T> : MyIterator<T>
    {
        bool HasPrevious();

        T Previous();

        int NextIndex();

        int PreviousIndex();

        void Set(T element);

        void Add(T element);
    }
}