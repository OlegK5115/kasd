using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task14
{
    class MyArrayDeque<T>
    {
        private T[] elems;
        private int root;
        private int back;
        public MyArrayDeque()
        {
            elems = new T[20];
            root = 0;
            back = -1;
        }
        public MyArrayDeque(T[] mass)
        {
            elems = new T[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                elems[i] = mass[i];
            }

            root = 0;
            back = mass.Length - 1;
        }
        public MyArrayDeque(int nums)
        {
            elems = new T[nums];
            root = 0;
            back = -1;
        }
        public void add(T elem)
        {
            if (back + 1 < elems.Length)
            {
                back++;
                elems[back] = elem;
                return;
            }
            if (getsize() < elems.Length)
            {
                root--;
                for (int i = root; i < back; i++)
                    elems[i] = elems[i + 1];
                elems[back] = elem;
                return;
            }
            T[] newelems = new T[2 * (elems.Length + 1)];
            for (int i = root; i <= back; i++)
                newelems[i] = elems[i];
            back++;
            newelems[back] = elem;
            elems = newelems;
        }
        public void add_all(T[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
                add(mass[i]);
        }
        public void clear()
        {
            back = -1;
            root = 0;
        }
        public bool contains(object o)
        {
            for (int i = root; i <= back; i++)
            {
                if (Equals(o, elems[i]))
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
                for (int j = root; j <= back; j++)
                {
                    if (Equals(mass[i], elems[j])) { check = true; }
                }
                    
                if (!check) { return false; }
            }
            return true;
        }
        public bool is_empty()
        {
            return root > back;
        }
        public void remove(object o)
        {
            for (int i = root; i <= back; i++)
                if (Equals(o, elems[i]))
                {
                    for (int j = i; j < back; j++) { elems[j] = elems[j + 1]; }
                    back--;
                    i--;
                }
        }
        public void remove_all(T[] mass)
        {
            for (int i = 0; i < mass.Length; i++) { remove(mass[i]); }
        }
        public void retain_all(T[] mass)
        {
            bool check;
            for (int i = root; i <= back; i++)
            {
                check = false;
                for (int j = 0; j < mass.Length; j++)
                {
                    if (Equals(elems[i], mass[j])) { check = true; }
                }
                    
                if (!check) { remove(mass[i]); }
            }
        }
        public int getsize()
        {
            return back - root + 1;
        }
        public T[] to_array()
        {
            T[] mass = new T[getsize()];
            int index = 0;
            for (int i = root; i <= back; i++)
            {
                mass[index] = elems[i];
                index++;
            }
            return mass;
        }
        public void to_array(ref T[] mass)
        {
            if (mass == null)
            {
                mass = to_array();
                return;
            }

            int index = 0;
            if (mass.Length == getsize())
            {
                for (int i = root; i <= back; i++)
                {
                    mass[index] = elems[i];
                    index++;
                }
                return;
            }

            mass = new T[getsize()];
            for (int i = root; i <= back; i++)
            {
                mass[index] = elems[i];
                index++;
            }
        }
        public T elem()
        {
            if (getsize() == 0) { throw new Exception("Deque is empty"); }
            return elems[root];
        }
        private int amount(T elem)
        {
            int massmount = 0;
            for (int i = root; i <= back; i++)
            {
                if (Equals(elem, elems[i])) { massmount++; }
                    
            }
                
            return massmount;
        }
        public bool offer(T elem)
        {
            int oldAmount = amount(elem);
            add(elem);

            int newAmount = amount(elem);
            if (oldAmount != newAmount) { return true; }
                
            return false;
        }
        public T peek()
        {
            if (getsize() == 0) { return default; }
            return elems[root];
        }
        public T poll()
        {
            if (getsize() == 0) { return default; }
            root++;

            return elems[root - 1];
        }
        public void add_first(T elem)
        {
            if (root - 1 >= 0)
            {
                root--;
                elems[root] = elem;
                return;
            }

            if (getsize() < elems.Length)
            {
                back++;
                for (int i = back; i > root; i--) {
                    elems[i] = elems[i - 1];
                }
                elems[root] = elem;
                return;
            }
            T[] newelems = new T[2 * (elems.Length + 1)];
            for (int i = root; i <= back; i++) {
                newelems[i + 1] = elems[i];
            }
                
            newelems[root] = elem;
            elems = newelems;
        }
        public void add_last(T elem)
        {
            add(elem);
        }
        public T get_first()
        {
            return elem();
        }
        public T get_last()
        {
            if (getsize() == 0) { throw new Exception("deque is empty"); }
            return elems[back];
        }
        public bool offer_first(T elem)
        {
            if (getsize() == elems.Length) { return false; }
            add_first(elem);
            return true;
        }
        public bool offer_last(T elem)
        {
            if (getsize() == elems.Length) { return false; }
            add_last(elem);

            return true;
        }
        public T pop()
        {
            if (getsize() == 0) { throw new Exception("Deque is empty"); }

            return poll();
        }
        public void push(T elem)
        {
            add_first(elem);
        }
        public T peek_first()
        {
            return peek();
        }
        public T peek_last()
        {
            if (getsize() == 0) { return default; }
            return elems[back];
        }
        public T poll_first()
        {
            return poll();
        }
        public T poll_last()
        {
            if (getsize() == 0) { return default; }
            back--;
            return elems[back + 1];
        }
        public T remove_first()
        {
            return pop();
        }
        public T remove_last()
        {
            if (getsize() == 0) { throw new Exception("deque is empty"); }
            back--;

            return elems[back + 1];
        }
        public bool remove_first_occurance(object o)
        {
            for (int i = root; i <= back; i++)
            {
                if (Equals(o, elems[i]))
                {
                    for (int j = i; j < back; j++)
                    {
                        elems[j] = elems[j + 1];
                    }
                    back--;

                    return true;
                }
            }
                
            return false;
        }
        public bool remove_last_occurance(object o)
        {
            for (int i = back; i >= root; i--)
            {
                if (Equals(o, elems[i]))
                {
                    for (int j = i; j < back; j++)
                    {
                        elems[j] = elems[j + 1];
                    }
                    back--;
                    return true;
                }
            }
                
            return false;
        }
    }
}
