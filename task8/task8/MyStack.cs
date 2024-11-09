using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    class MyStack<T> : MyVector<T>
    {
        public void push(T item)
        {
            add(item);
        }

        public T pop()
        {
            T result = elementData[elementCount - 1];
            remove(elementCount-1);

            return result;
        }

        public T peek()
        {
            T result = elementData[elementCount - 1];
            return result;
        }

        public bool empty()
        {
            return this.size() == 0;
        }

        public int search(T item)
        {
            int index = LastIndexOf(item);
            if (index == -1)
            {
                return -1;
            }
            return size() - index;
        }
    }
}
