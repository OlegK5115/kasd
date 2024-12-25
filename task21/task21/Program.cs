using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task21
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTreeMap<int, string> treeMap = new MyTreeMap<int, string>();
            foreach (var item in Enumerable.Range(1, 20))
            {
                treeMap.Put(item * 2, $"Value {item * 2}");
            }
            foreach (var item in Enumerable.Range(1, 20))
            {
                treeMap.Put(item, $"Value {item}");
            }

            treeMap.Print();

            Console.ReadLine();
        }
    }
}
