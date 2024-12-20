using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task19
{
    class Node<T>
    {
        public T value;
        public Node<T> next;
        public Node<T> prev;
        public Node()
        {
            value = default;
            next = null;
            prev = null;
        }
        public Node(T value, Node<T> next, Node<T> prev)
        {
            this.value = value;
            this.next = next;
            this.prev = prev;
        }
    }
}
