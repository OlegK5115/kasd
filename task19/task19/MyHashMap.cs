using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task19
{
    class MyHashMap<K, V>
    {
        private MyLinkedList<Pair<K, V>>[] table;
        private int size;
        private double load_factor;
        public MyHashMap()
        {
            table = new MyLinkedList<Pair<K, V>>[20];
            for (int i = 0; i < 20; i++)
            {
                table[i] = new MyLinkedList<Pair<K, V>>();
            }

            size = 0;
            load_factor = 0.75;
        }
        public MyHashMap(int init_capacity)
        {
            if (init_capacity <= 0)
            {
                throw new ArgumentException("init capacity");
            }
            table = new MyLinkedList<Pair<K, V>>[init_capacity];

            for (int i = 0; i < init_capacity; i++)
            {
                table[i] = new MyLinkedList<Pair<K, V>>();
            }
            size = 0;
            load_factor = 0.75;
        }
        public MyHashMap(int init_capacity, double load_factor)
        {
            if (init_capacity <= 0)
            {
                throw new ArgumentException("Initial capacity");
            }

            if (load_factor <= 0 || 1 <= load_factor)
            {
                throw new ArgumentException("Load factor");
            }

            table = new MyLinkedList<Pair<K, V>>[init_capacity];
            for (int i = 0; i < init_capacity; i++)
            {
                table[i] = new MyLinkedList<Pair<K, V>>();
            }
            size = 0;
            this.load_factor = 0.75;
        }
        private int get_hash_index(object obj)
        {
            return Math.Abs(obj.GetHashCode()) % table.Length;
        }
        private int get_new_hash_index(object obj, int module)
        {
            return Math.Abs(obj.GetHashCode()) % module;
        }
        public void print()
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].getsize() != 0)
                {
                    for (int j = 0; j < table[i].getsize(); j++)
                    {
                        Console.Write($"({table[i].get(j).key}: {table[i].get(j).value})");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void clear()
        {
            table = new MyLinkedList<Pair<K, V>>[16];
            for (int i = 0; i < 16; i++)
            {
                table[i] = new MyLinkedList<Pair<K, V>>();
            }

            size = 0;
        }
        public bool contains_key(object key)
        {
            int index = get_hash_index(key);
            if (table[index].getsize() == 0) { return false; }
            Node<Pair<K, V>> p = table[index].get_first_node();

            while (p != null)
            {
                if (Equals(p.value.key, key)) { return true; }
                p = p.next;
            }
            return false;
        }
        public bool contains_value(object value)
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].getsize() == 0) { continue; }
                Node<Pair<K, V>> p = table[i].get_first_node();
                while (p != null)
                {
                    if (Equals(p.value.value, value)) { return true; }
                    p = p.next;
                }
            }
            return false;
        }
        public MyHashMap<Pair<K, V>, byte> entry_set()
        {
            MyHashMap<Pair<K, V>, byte> set = new MyHashMap<Pair<K, V>, byte>();
            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < table[i].getsize(); j++)
                {
                    set.put(table[i].get(j), 0);
                }
            }

            return set;
        }
        public V get(object key)
        {
            int index = get_hash_index(key);
            if (table[index].getsize() == 0)
            {
                return default;
            }

            Node<Pair<K, V>> p = table[index].get_first_node();
            while (p != null)
            {
                if (Equals(p.value.key, key))
                {
                    return p.value.value;
                }

                p = p.next;
            }
            return default;
        }
        public bool is_empty()
        {
            return size == 0;
        }
        public MyHashMap<K, byte> key_set()
        {
            MyHashMap<K, byte> set = new MyHashMap<K, byte>();
            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < table[i].getsize(); j++)
                {
                    set.put(table[i].get(j).key, 0);
                }
            }

            return set;
        }
        public void regetsize()
        {
            MyLinkedList<Pair<K, V>>[] newTable = new MyLinkedList<Pair<K, V>>[table.Length * 2];
            for (int i = 0; i < table.Length * 2; i++)
            {
                newTable[i] = new MyLinkedList<Pair<K, V>>();
            }

            int index;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].getsize() == 0) { continue; }

                index = get_new_hash_index(table[i].get_first_node().value.key, newTable.Length);
                newTable[index] = table[i];
                table[i] = new MyLinkedList<Pair<K, V>>();
            }
            table = newTable;
        }
        public void put(K key, V value)
        {
            if ((double)size / table.Length > load_factor)
            {
                regetsize();
            }

            int index = get_hash_index(key);
            if (table[index].getsize() == 0)
            {
                table[index] = new MyLinkedList<Pair<K, V>>();
                Pair<K, V> pair = new Pair<K, V>(key, value);
                table[index].add(pair);
                size++;
                return;
            }

            Node<Pair<K, V>> p = table[index].get_first_node();
            while (p != null)
            {
                if (Equals(p.value.key, key))
                {
                    p.value.value = value;
                    size++;
                    return;
                }
                p = p.next;
            }

            Pair<K, V> newPair = new Pair<K, V>(key, value);
            table[index].add(newPair);
            size++;
        }
        public void remove(object key)
        {
            int index = get_hash_index(key);
            if (table[index].getsize() == 0) { return; }

            Node<Pair<K, V>> p = table[index].get_first_node();
            while (p != null)
            {
                if (Equals(p.value.key, key))
                {
                    Pair<K, V> pair = new Pair<K, V>((K)key, p.value.value);
                    table[index].remove(pair);
                    size--;
                    return;
                }
                p = p.next;
            }
        }
        public int getsize()
        {
            return size;
        }
    }
}
