using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task16
{
    class MyLinkedList<T>
    {
        private Node<T> left, right;
        private int size;
        public MyLinkedList()
        {
            size = 0;
            left = null;
            right = null;
        }
        public MyLinkedList(T[] mass)
        {
            if (mass.Length == 0)
            {
                size = 0;
                left = null;
                right = null;
                return;
            }

            if (mass.Length == 1)
            {
                Node<T> node = new Node<T>(mass[0], null, null);
                size = 1;
                left = node;
                right = node;
                return;
            }

            Node<T> begin = new Node<T>(mass[0], null, null);
            Node<T> p = begin;
            Node<T> q = new Node<T>();
            Node<T> end;
            for (int i = 1; i < mass.Length; i++)
            {
                q = new Node<T>(mass[i], null, p);
                p.next = q;
                p = q;
            }
            end = q;
            left = begin;
            right = end;
            size = mass.Length;
        }
        public void print()
        {
            Node<T> p = left;
            while (p != null)
            {
                Console.Write(p.value + " ");
                p = p.next;
            }
            Console.Write('\n');
        }
        public void add(T elem)
        {
            Node<T> node = new Node<T>(elem, null, right);
            if (size == 0)
            {
                left = right = node;
                size++;
                return;
            }
            right.next = node;
            right = node;
            size++;
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
            left = null;
            right = null;
            size = 0;
        }
        public bool contains(object o)
        {
            Node<T> p = left;
            while (p != null)
            {
                if (Equals(p.value, o)) { return true; }
                p = p.next;
            }
            return false;
        }
        public bool contains_all(T[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (!contains(mass[i])) { return false; }
            }
                
            return true;
        }
        public bool is_empty()
        {
            return size == 0;
        }
        public void remove(object o)
        {
            if (left == null) { return; }
            Node<T> p = left.next;
            if (p != null)
            {
                while (p.next != null)
                {
                    if (Equals(p.value, o))
                    {
                        p.prev.next = p.next;
                        p.next.prev = p.prev;
                        size--;
                    }
                    p = p.next;
                }
            }
            if (Equals(left.value, o))
            {
                left = left.next;
                if (left != null) { left.prev = null; }
                size--;
            }
            if (Equals(right.value, o))
            {
                right = right.prev;
                if (right != null) { right.next = null; }
                size--;
            }
            if (left == null || right == null)
            {
                left = null;
                right = null;
            }
        }
        public void remove_all(T[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                remove(mass[i]);
            }
        }
        public void retain_all(T[] mass)
        {
            Node<T> p = left;
            bool flag;
            while (p != null)
            {
                flag = false;
                for (int i = 0; i < mass.Length && !flag; i++)
                {
                    if (Equals(mass[i], p.value)) { flag = true; }
                }
                if (!flag) { remove(p.value); }

                p = p.next;
            }
        }
        public int getsize()
        {
            return size;
        }
        public T[] to_array()
        {
            T[] mass = new T[size];
            Node<T> p = left;
            int i = 0;
            while (p != null)
            {
                mass[i] = p.value;
                i++;
                p = p.next;
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
            Node<T> p = left;
            int i = 0;
            if (mass.Length == size)
            {
                while (p != null)
                {
                    mass[i] = p.value;
                    i++;
                    p = p.next;
                }
                return;
            }
            mass = new T[size];
            while (p != null)
            {
                mass[i] = p.value;
                i++;
                p = p.next;
            }
        }
        public void add(int ind, T elem)
        {
            if (ind < 0 || ind > size) { throw new ArgumentOutOfRangeException("index"); }
            if (ind == 0)
            {
                Node<T> node = new Node<T>(elem, left, null);
                if (left != null)
                {
                    left.prev = node;
                }
                    
                left = node;
                if (right == null)
                {
                    right = left;
                }
                    
                size++;
                return;
            }
            if (ind == size)
            {
                add(elem);
                return;
            }
            Node<T> p = left;
            for (int i = 0; i < ind; i++) { p = p.next; }
                
            Node<T> newNode = new Node<T>(elem, p, p.prev);
            p.prev.next = newNode;
            p.prev = newNode;
            size++;
        }
        public void add_all(int ind, T[] mass)
        {
            if (ind < 0 || ind > size)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            for (int i = mass.Length - 1; i >= 0; i--)
            {
                add(ind, mass[i]);
            }
        }
        public T get(int ind)
        {
            if (ind < 0 || ind > size - 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            Node<T> p = left;
            for (int i = 0; i < ind; i++) { p = p.next; }
            return p.value;
        }
        public int index_of(object o)
        {
            Node<T> p = left;
            int ind = 0;
            while (p != null)
            {
                if (Equals(p.value, o))
                {
                    return ind;
                }
                ind++;
                p = p.next;
            }
            return -1;
        }
        public int right_index_of(object o)
        {
            Node<T> p = right;
            int ind = size - 1;
            while (p != null)
            {
                if (Equals(p.value, o))
                {
                    return ind;
                }
                ind--;
                p = p.prev;
            }
            return -1;
        }
        public T remove_at(int ind)
        {
            if (ind < 0 || ind > size - 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (ind == 0)
            {
                T element = left.value;
                left = left.next;
                if (left != null) { left.prev = null; }
                if (left == null) { right = null; }
                size--;
                return element;
            }
            if (ind == size - 1)
            {
                T element = right.value;
                right = right.prev;
                if (right != null) { right.next = null; }
                if (right == null) { left = null; }
                size--;
                return element;
            }

            Node<T> p = left;
            for (int i = 0; i < ind; i++)
            {
                p = p.next;
            }
            T value = p.value;
            p.prev.next = p.next;
            p.next.prev = p.prev;
            size--;

            return value;
        }
        public void set(int ind, T elem)
        {
            if (ind < 0 || ind > size - 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            Node<T> p = left;

            for (int i = 0; i < ind; i++) { p = p.next; }
            p.value = elem;
        }
        public MyLinkedList<T> sub_list(int beg, int end)
        {
            if (beg < 0 || beg > size - 1) { throw new ArgumentOutOfRangeException("begin index"); }
            if (end < 0 || end > size) { throw new ArgumentOutOfRangeException("end index"); }

            MyLinkedList<T> list = new MyLinkedList<T>();
            Node<T> p = left;
            for (int i = 0; i < beg; i++) { p = p.next; }

            for (int i = 0; i < end - beg; i++)
            {
                list.add(p.value);
                p = p.next;
            }

            return list;
        }
        public T element()
        {
            if (size == 0)
            {
                throw new ArgumentOutOfRangeException("list is empty");
            }

            return get(0);
        }
        private int amount(object obj)
        {
            int amount = 0;
            Node<T> p = left;
            while (p != null)
            {
                if (Equals(p.value, obj)) { amount++; }
                p = p.next;
            }
            return amount;
        }
        public bool offer(T elem)
        {
            int old_amount = amount(elem);
            add(elem);
            int new_amount = amount(elem);

            return old_amount != new_amount;
        }
        public T peek()
        {
            if (size == 0) { return default; }

            return get(0);
        }
        public T poll()
        {
            if (size == 0)
            {
                return default;
            }

            T element = get(0);
            remove_at(0);

            return element;
        }
        public void add_left(T element)
        {
            add(0, element);
        }
        public void add_right(T element)
        {
            add(element);
        }
        public T get_left()
        {
            return get(0);
        }
        public T get_right()
        {
            return get(getsize() - 1);
        }
        public bool offer_left(T element)
        {
            int oldAmount = amount(element);
            add(0, element);
            int newAmount = amount(element);

            return oldAmount != newAmount;
        }
        public bool offer_right(T element)
        {
            return offer(element);
        }
        public T pop()
        {
            if (size == 0)
            {
                throw new ArgumentOutOfRangeException("list is empty");
            }
            return poll();
        }
        public void push(T element)
        {
            add_left(element);
        }
        public T peek_left()
        {
            if (size == 0)
            {
                return default;
            }

            return get_left();
        }
        public T peek_right()
        {
            if (size == 0)
            {
                return default;
            }

            return get_right();
        }
        public T poll_left()
        {
            return poll();
        }
        public T poll_right()
        {
            if (size == 0) { return default; }
            T element = get(getsize() - 1);
            remove_at(getsize() - 1);

            return element;
        }
        public T remove_right()
        {
            return remove_at(getsize() - 1);
        }
        public T remove_left()
        {
            return remove_at(0);
        }
        public bool remove_left_occurrence(object obj)
        {
            int index = index_of(obj);
            if (index == -1) { return false; }

            remove_at(index);
            return true;
        }
        public bool remove_right_occurrence(object obj)
        {
            int index = right_index_of(obj);
            if (index == -1) { return false; }
                
            remove_at(index);
            return true;
        }
    }
}