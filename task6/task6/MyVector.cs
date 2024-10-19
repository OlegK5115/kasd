using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    class MyVector<T>
    {
        T[] elementData;
        int elementCount;
        int capacityIncrement;

        public T this[int i]
        {
            get
            {
                return elementData[i];
            }

            set
            {
                set(i, value);
            }
        }

        public MyVector(int initialCapacity, int capacityIncrement)
        {
            this.capacityIncrement = capacityIncrement;
            elementData = new T[initialCapacity];
        }

        public MyVector(int initialCapacity)
        {
            capacityIncrement = 0;
            elementData = new T[initialCapacity];
        }

        public MyVector()
        {
            elementData = new T[10];
        }

        public MyVector(T[] a)
        {
            elementCount = a.Length;
            elementData = new T[a.Length];
            for (int i = 0; i < elementCount; i++)
            {
                elementData[i] = a[i];
            }
            capacityIncrement = 0;
        }

        public void add(T e)
        {
            if (elementCount >= elementData.Length)
            {
                increaseArray();
            }

            elementData[elementCount++] = e;
        }

        public void addAll(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                add(a[i]);
            }
        }

        public void clear()
        {
            for (int i = 0; i < elementCount; i++)
            {
                elementData[i] = default(T);
            }
            elementCount = 0;
        }

        public bool contains(T o)
        {
            return IndexOf(o) > -1;
        }

        public bool containsAll(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!contains(a[i])) { return false; }
            }

            return true;
        }

        public bool isEmpty()
        {
            return elementCount == 0;
        }

        public void remove(T o)
        {
            int index = -1;
            for (int i = elementCount - 1; i >= 0; i--)
            {
                if (Equals(elementData[i], o))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) { return; }

            for (int i = index; i < elementCount - 1; i++)
            {
                elementData[i] = elementData[i + 1];
            }
            elementCount--;
        }

        public void removeAll(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                remove(a[i]);
            }
        }

        public void retainAll(T[] a)
        {
            for (int i = 0; i < elementCount; i++)
            {
                if (Array.IndexOf(a, elementData[i]) == -1)
                {
                    remove(elementData[i]);
                }
            }
        }

        public int size() { return elementCount; }

        public T[] toArray()
        {
            T[] new_mass = new T[elementCount];
            Array.Copy(elementData, new_mass, elementCount);
            return new_mass;
        }

        public void toArray(T[] a)
        {
            if (a == null || a.Length < elementCount) throw new ArgumentOutOfRangeException();
            for (int i = 0; i < elementData.Length; i++)
            {
                a[i] = elementData[i];
            }
        }

        public void Add(int index, T e)
        {
            if (index < 0 || index >= elementCount) { throw new ArgumentOutOfRangeException(); }

            if (elementCount == elementData.Length) { increaseArray(); }

            for (int i = elementCount; i > index; i--)
            {
                elementData[i] = elementData[i - 1];
            }

            elementData[index] = e;
            elementCount++;
        }

        public void AddAll(int index, T[] array)
        {
            for (int i = index; i < array.Length; i++)
            {
                Add(i, array[i]);
            }
        }

        public T get(int index) { return elementData[index]; }

        public int IndexOf(T o)
        {
            for (int i = 0; i < elementCount; i++)
            {
                if (Equals(o, elementData[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public int LastIndexOf(T item)
        {
            for (int i = elementCount - 1; i >= 0; i--)
            {
                if (Equals(item, elementData[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public T remove(int index)
        {
            if (index < 0 || index >= elementCount) { throw new ArgumentOutOfRangeException(); }

            T answer = elementData[index];
            for (int i = index; i < elementCount - 1; i++)
            {
                elementData[i] = elementData[i + 1];
            }
            elementCount--;
            return answer;
        }

        public void set(int index, T e)
        {
            if (index < 0 || index >= elementCount) { throw new ArgumentOutOfRangeException(); }
            elementData[index] = e;
        }

        public T[] SubList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || toIndex < fromIndex || toIndex > elementCount) { throw new ArgumentOutOfRangeException(); }

            T[] result = new T[toIndex - fromIndex];

            for (int i = fromIndex; i < toIndex; i++)
            {
                result[i] = elementData[i];
            }

            return result;
        }

        public T firstElement() { return elementData[0]; }

        public T lastElement() { return elementData[elementCount - 1]; }

        public void removeElementAt(int pos)
        {
            remove(pos);
        }

        public void removeRange(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                removeElementAt(start);
            }
        }

        private void increaseArray()
        {
            int new_elementCount = capacityIncrement == 0 ? elementData.Length * 2 : elementData.Length + capacityIncrement;
            T[] newArray = new T[new_elementCount];
            for (int i = 0; i < elementData.Length; i++)
            {
                newArray[i] = elementData[i];
            }
            elementData = newArray;
        }
    }
}
