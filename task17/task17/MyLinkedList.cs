using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task17
{
    class MyLinkedList<T>
    {
        private Node<T> first, last;
        private int size;
        public MyLinkedList()
        {
            size = 0;
            first = null;
            last = null;
        }
        public MyLinkedList(T[] mass)
        {
            if (mass.Length == 0)
            {
                size = 0;
                first = null;
                last = null;
                return;
            }
            if (mass.Length == 1)
            {
                Node<T> node = new Node<T>(mass[0], null, null);
                size = 1;
                first = node;
                last = node;
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
            first = begin;
            last = end;
            size = mass.Length;
        }
        public void print()
        {
            Node<T> p = first;
            while (p != null)
            {
                Console.Write(p.value + " ");
                p = p.next;
            }
            Console.Write('\n');
        }
        public void add(T elem)
        {
            Node<T> node = new Node<T>(elem, null, last);
            if (size == 0)
            {
                first = last = node;
                size++;
                return;
            }
            last.next = node;
            last = node;
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
            first = null;
            last = null;
            size = 0;
        }
        public bool contains(object o)
        {
            Node<T> p = first;
            while (p != null)
            {
                if (Equals(p.value, o))
                {
                    return true;
                }
                p = p.next;
            }
            return false;
        }
        public bool contains_all(T[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (!contains(mass[i]))
                {
                    return false;
                }
            }

            return true;
        }
        public bool is_empty()
        {
            return size == 0;
        }
        public void remove(object o)
        {
            if (first == null) { return; }
            Node<T> p = first.next;
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
            if (Equals(first.value, o))
            {
                first = first.next;
                if (first != null) { first.prev = null; }
                size--;
            }
            if (Equals(last.value, o))
            {
                last = last.prev;
                if (last != null) { last.next = null; }
                size--;
            }
            if (first == null || last == null)
            {
                first = null;
                last = null;
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
            Node<T> p = first;
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
            Node<T> p = first;
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
            Node<T> p = first;
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
            if (ind < 0 || ind > size) { throw new ArgumentOutOfRangeException("Index"); }
            if (ind == 0)
            {
                Node<T> node = new Node<T>(elem, first, null);
                if (first != null)
                {
                    first.prev = node;
                }

                first = node;
                if (last == null)
                {
                    last = first;
                }

                size++;
                return;
            }
            if (ind == size)
            {
                add(elem);
                return;
            }
            Node<T> p = first;
            for (int i = 0; i < ind; i++)
                p = p.next;
            Node<T> newNode = new Node<T>(elem, p, p.prev);
            p.prev.next = newNode;
            p.prev = newNode;
            size++;
        }
        public void add_all(int ind, T[] mass)
        {
            if (ind < 0 || ind > size)
            {
                throw new ArgumentOutOfRangeException("Index");
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
                throw new ArgumentOutOfRangeException("Index");
            }

            Node<T> p = first;
            for (int i = 0; i < ind; i++) { p = p.next; }
            return p.value;
        }
        public int index_of(object o)
        {
            Node<T> p = first;
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
        public int last_index_of(object o)
        {
            Node<T> p = last;
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
                throw new ArgumentOutOfRangeException("Index");
            }
            if (ind == 0)
            {
                T element = first.value;
                first = first.next;
                if (first != null) { first.prev = null; }
                if (first == null) { last = null; }
                size--;
                return element;
            }
            if (ind == size - 1)
            {
                T element = last.value;
                last = last.prev;
                if (last != null) { last.next = null; }
                if (last == null) { first = null; }
                size--;
                return element;
            }

            Node<T> p = first;
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
                throw new ArgumentOutOfRangeException("Index");
            }
            Node<T> p = first;

            for (int i = 0; i < ind; i++) { p = p.next; }
            p.value = elem;
        }
        public MyLinkedList<T> sub_list(int beg, int end)
        {
            if (beg < 0 || beg > size - 1) { throw new ArgumentOutOfRangeException("BeginIndex"); }
            if (end < 0 || end > size) { throw new ArgumentOutOfRangeException("EndIndex"); }

            MyLinkedList<T> list = new MyLinkedList<T>();
            Node<T> p = first;
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
                throw new ArgumentOutOfRangeException("ListIsEmpty");
            }

            return get(0);
        }
        private int amount(object obj)
        {
            int amount = 0;
            Node<T> p = first;
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
        public void add_first(T element)
        {
            add(0, element);
        }
        public void add_last(T element)
        {
            add(element);
        }
        public T get_first()
        {
            return get(0);
        }
        public T get_last()
        {
            return get(getsize() - 1);
        }
        public bool offer_first(T element)
        {
            int oldAmount = amount(element);
            add(0, element);
            int newAmount = amount(element);

            return oldAmount != newAmount;
        }
        public bool offer_last(T element)
        {
            return offer(element);
        }
        public T pop()
        {
            if (size == 0)
            {
                throw new ArgumentOutOfRangeException("ListIsEmpty");
            }
            return poll();
        }
        public void push(T element)
        {
            add_first(element);
        }
        public T peek_first()
        {
            if (size == 0)
            {
                return default;
            }

            return get_first();
        }
        public T peek_last()
        {
            if (size == 0)
            {
                return default;
            }

            return get_last();
        }
        public T poll_first()
        {
            return poll();
        }
        public T poll_last()
        {
            if (size == 0) { return default; }
            T element = get(getsize() - 1);
            remove_at(getsize() - 1);

            return element;
        }
        public T remove_last()
        {
            return remove_at(getsize() - 1);
        }
        public T remove_first()
        {
            return remove_at(0);
        }
        public bool remove_first_occurrence(object obj)
        {
            int index = index_of(obj);
            if (index == -1) { return false; }

            remove_at(index);
            return true;
        }
        public bool remove_last_occurrence(object obj)
        {
            int index = last_index_of(obj);
            if (index == -1) { return false; }

            remove_at(index);
            return true;
        }
    }
}