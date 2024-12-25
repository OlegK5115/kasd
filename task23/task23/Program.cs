using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task23
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashSet<int> set = new MyHashSet<int>();

            set.AddAll(Enumerable.Range(1, 10).ToArray());
            set.Remove(3);
            set.Add(5);
            set.Add(5);

            int[] newArray = set.ToArray();
            for (int i = 0; i < newArray.Length; i++)
            {
                Console.Write(newArray[i] + " ");
            }

            Console.ReadLine();
        }
    }
}
