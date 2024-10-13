using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class MyArrayList<T>
    {
        static int baseLen = 10;
        int size;
        T[] elementData;

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= size) { throw new IndexOutOfRangeException(); }
                return elementData[i];
            }
            set
            {
                if (i < 0 || i >= size) { throw new IndexOutOfRangeException(); }
                elementData[i] = value;
            }
        }
        public MyArrayList()
        {
            elementData = new T[baseLen];
            size = 0;
        }
        public MyArrayList(T[] a)
        {
            size = a.Length;
            elementData = new T[size];
            for (int i = 0; i < size; i++)
            {
                elementData[i] = a[i];
            }
        }
        public MyArrayList(int capacity)
        {
            elementData = new T[capacity];
            size = 0;
        }

        public void add(T e)
        {
            if (size == elementData.Length)
            {
                increaseArray();
            }

            elementData[size++] = e;
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
            for (int i = 0; i < size; i++)
            {
                elementData[i] = default(T);
            }
            size = 0;
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
            return size == 0;
        }
        public void remove(T o)
        {
            int index = -1;
            for (int i = 0; i < size; i++)
            {
                if (Equals(elementData[i], o))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) { return; }

            for (int i = index; i < size - 1; i++)
            {
                elementData[i] = elementData[i + 1];
            }
            size--;
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
            for (int i = 0; i < size; i++)
            {
                if (Array.IndexOf(a, elementData[i]) == -1)
                {
                    remove(elementData[i]);
                }
            }
        }
        public int getSize() { return size; }
        public T[] toArray()
        {
            T[] new_mass = new T[size];
            Array.Copy(elementData, new_mass, size);
            return new_mass;
        }
        public void toArray(T[] a)
        {
            if (a == null || a.Length < size) throw new ArgumentOutOfRangeException();
            for (int i = 0; i < elementData.Length; i++)
            {
                a[i] = elementData[i];
            }
        }

        public void Add(int index, T e)
        {
            if (index < 0 || index >= size) { throw new ArgumentOutOfRangeException(); }

            if (size == elementData.Length) { increaseArray(); }

            for (int i = size; i > index; i--)
            {
                elementData[i] = elementData[i - 1];
            }

            elementData[index] = e;
            size++;
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
            for (int i = 0; i < size; i++)
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
            for (int i = size - 1; i >= 0; i--)
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
            if (index < 0 || index >= size) { throw new ArgumentOutOfRangeException(); }

            T answer = elementData[index];
            for (int i = index; i < size - 1; i++)
            {
                elementData[i] = elementData[i + 1];
            }
            size--;
            return answer;
        }
        public void set(int index, T e)
        {
            if (index < 0 || index >= size) { throw new ArgumentOutOfRangeException(); }
            elementData[index] = e;
        }
        public T[] SubList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || toIndex < fromIndex || toIndex > size) { throw new ArgumentOutOfRangeException(); }

            T[] result = new T[toIndex - fromIndex];

            for (int i = fromIndex; i < toIndex; i++)
            {
                result[i] = elementData[i];
            }

            return result;
        }
        private void increaseArray()
        {
            T[] newArray = new T[(int)(1.5 * size) + 1];
            for (int i = 0; i < size; i++)
            {
                newArray[i] = elementData[i];
            }
            elementData = newArray;
        }
    }
}
