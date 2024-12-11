using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11
{
    class MyPriorityQueue<T> where T : IComparable<T>
    {
        private T[] queue;
        private int size;
        private Comparer<T> comparator;
        public MyPriorityQueue()
        {
            queue = new T[10];
            size = 0;
            comparator = Comparer<T>.Default;
        }
        public MyPriorityQueue(T[] mass)
        {
            size = mass.Length;
            queue = new T[size];

            for (int i = 0; i < size; i++)
            {
                queue[i] = mass[i];
            }
            comparator = Comparer<T>.Default;
            rebuild();
        }
        public MyPriorityQueue(int init_size)
        {
            queue = new T[init_size];
            size = 0;
            comparator = Comparer<T>.Default;
        }
        public MyPriorityQueue(int init_size, Comparer<T> comp)
        {
            queue = new T[init_size];
            size = 0;
            this.comparator = comp;
        }
        public MyPriorityQueue(MyPriorityQueue<T> q)
        {
            queue = q.to_array();
            size = q.getsize();
            comparator = q.comparator_get();
        }
        public object this[int index]
        {
            get { return queue[index]; }
        }
        public Comparer<T> comparator_get()
        {
            return comparator;
        }
        public void comparator_set(Comparer<T> comp)
        {
            this.comparator = comp;
        }
        private void rebuild()
        {
            MyHeap<T> my_heap = new MyHeap<T>(queue);
            my_heap.set_comparator(comparator);
            for (int i = 0; i < size; i++)
            {
                queue[i] = my_heap.get(i);
            }
        }
        public void add(T elem)
        {
            if (size < queue.Length)
            {
                queue[size] = elem;
                size++;
                rebuild();
                return;
            }

            int new_size;
            if (queue.Length < 64) {
                new_size = queue.Length + 2;
            }
            else {
                new_size = (int)(queue.Length * 1.5);
            }

            T[] newQueue = new T[new_size];
            for (int i = 0; i < size; i++) {
                newQueue[i] = queue[i];
            }

            newQueue[size] = elem;
            queue = newQueue;
            size++;

            rebuild();
        }
        public void add_all(T[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                add(mass[i]);
            }
        }
        public void clear()
        {
            size = 0;
        }
        public bool contains(object o)
        {
            for (int i = 0; i < size; i++)
            {
                if (comparator.Compare((T)o, queue[i]) == 0)
                {
                    return true;
                }
            }

            return false;
        }
        public bool contains_all(T[] mass)
        {
            bool check;
            for (int i = 0; i < mass.Length; i++)
            {
                check = false;
                for (int j = 0; j < size; j++)
                {
                    if (comparator.Compare(mass[i], queue[j]) == 0)
                    {
                        check = true;
                    }
                }

                if (!check) { return false; }
            }

            return true;
        }
        public bool is_empty()
        {
            return size == 0;
        }
        public void remove(object o)
        {
            for (int i = 0; i < size; i++)
            {
                if (comparator.Compare((T)o, queue[i]) == 0)
                {
                    for (int j = i; j < size - 1; j++)
                    {
                        queue[j] = queue[j + 1];
                    }
                    i--;
                    size--;
                }
            }
            
            rebuild();
        }
        public void remove_all(T[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
                remove(mass[i]);
        }
        public void retain_all(T[] mass)
        {
            bool check;
            for (int i = 0; i < size; i++)
            {
                check = false;
                for (int j = 0; j < mass.Length; j++)
                {
                    if (comparator.Compare(mass[i], queue[j]) == 0)
                    {
                        check = true;
                    }
                }
                    
                if (!check)
                {
                    remove(mass[i]);
                }
            }

            rebuild();
        }
        public int getsize()
        {
            return size;
        }
        public T[] to_array()
        {
            T[] mass = new T[size];
            for (int i = 0; i < size; i++) { mass[i] = queue[i]; }
            return mass;
        }
        public void to_array(ref T[] mass)
        {
            if (mass == null)
            {
                mass = to_array();
                return;
            }
            if (mass.Length == size)
            {
                for (int i = 0; i < size; i++)
                {
                    mass[i] = queue[i];
                }
                return;
            }
            mass = new T[size];
            for (int i = 0; i < size; i++)
            {
                mass[i] = queue[i];
            }
        }
        public T element()
        {
            if (size == 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return queue[0];
        }
        private int amount(T o)
        {
            int amount = 0;
            for (int i = 0; i < size; i++)
            {
                if (comparator.Compare(o, queue[i]) == 0)
                {
                    amount++;
                }
            }

            return amount;
        }
        public bool offer(T o)
        {
            int old_amount = amount(o);
            add(o);

            int new_amount = amount(o);
            if (old_amount != new_amount)
            {
                return true;
            }

            return false;
        }
        public T Peek()
        {
            if (size == 0)
            {
                return default;
            }

            return queue[0];
        }
        public T Poll()
        {
            if (size == 0) { return default; }
            T elem = queue[0];
            for (int i = 0; i < size - 1; i++)
            {
                queue[i] = queue[i + 1];
            }
            size--;
            rebuild();

            return elem;
        }
    }
}
