using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task28
{
    public interface IMySet<E> : IMyCollection<E>
    {
        E First();
        E Last();
        IMySet<E> SubSet(E fromElement, E toElement);
        IMySet<E> HeadSet(E toElement);
        IMySet<E> TailSet(E fromElement);
    }
}
