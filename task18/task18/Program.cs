using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task18
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashMap<string, int> myHashMap = new MyHashMap<string, int>(3);

            myHashMap.put("Cap", 10);
            myHashMap.put("Hat", 40);
            myHashMap.put("Mask", 400);
            myHashMap.print();
            Console.WriteLine();

            Console.WriteLine(myHashMap.get("Cap"));
            Console.WriteLine(myHashMap.get("Mask"));
            Console.WriteLine();

            myHashMap.put("T-Shirt", 100);
            myHashMap.put("Boots", 350);
            myHashMap.print();
            Console.WriteLine();

            myHashMap.entry_set().print();
            Console.WriteLine();

            myHashMap.key_set().print();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}