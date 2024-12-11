using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12
{
    class MyHeap<T> where T : IComparable<T>
    {
        private T[] elementData;
        private int elementCount;
        private Comparer<T> comparator;

        private void rebuild()
        {
            for (int i = elementCount - 1; i >= 0; i--)
            {
                int left, right;
                int root = i;
                T temp;
                bool check = true;
                while (check)
                {
                    check = false;
                    left = 2 * i + 1;
                    right = 2 * i + 2;
                    if (left < elementCount && comparator.Compare(elementData[left], elementData[root]) > 0) { root = left; }
                    if (right < elementCount && comparator.Compare(elementData[right], elementData[root]) > 0) { root = right; }
                    if (root != i)
                    {
                        temp = elementData[i];
                        elementData[i] = elementData[root];
                        elementData[root] = temp;
                        i = root;
                        check = true;
                    }
                }
            }
        }
        public MyHeap(T[] mass)
        {
            elementCount = mass.Length;
            elementData = new T[elementCount];
            for (int i = 0; i < elementCount; i++) { elementData[i] = mass[i]; }
            comparator = Comparer<T>.Default;
            rebuild();
        }

        public object this[int index]
        {
            get { return elementData[index]; }
        }
        public Comparer<T> get_comparator()
        {
            return comparator;
        }
        public void set_comparator(Comparer<T> comparator)
        {
            this.comparator = comparator;
        }

        public T get_maxvalue()
        {
            if (elementCount == 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return elementData[0];
        }
        public T pop_maxvalue()
        {
            if (elementCount == 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            T maxValue = elementData[0];
            for (int i = 0; i < elementCount - 1; i++)
            {
                elementData[i] = elementData[i + 1];
            }
            elementCount--;
            rebuild();

            return maxValue;
        }
        public void set(int index, T element)
        {
            if (index < 0 || index >= elementCount)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            elementData[index] = element;
            rebuild();
        }
        public T get(int index)
        {
            if (index < 0 || index >= elementCount)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return elementData[index];
        }
        public void add(T element)
        {
            if (elementCount < elementData.Length)
            {
                elementData[elementCount] = element;
                elementCount++;
                rebuild();
                return;
            }

            T[] new_elem_data = new T[2 * elementData.Length + 1];
            for (int i = 0; i < elementCount; i++)
            {
                new_elem_data[i] = elementData[i];
            }

            new_elem_data[elementCount] = element;
            elementData = new_elem_data;
            elementCount++;
            rebuild();
        }
        public int size() { return elementCount; }
        public void merge(MyHeap<T> myHeap)
        {
            T[] new_elem_data = new T[elementCount + myHeap.size()];
            for (int i = 0; i < elementCount; i++) { new_elem_data[i] = elementData[i]; }

            for (int i = 0; i < myHeap.size(); i++) { new_elem_data[elementCount + i] = myHeap.get(i); }

            elementData = new_elem_data;
            elementCount += myHeap.size();
            rebuild();
        }
    }
}