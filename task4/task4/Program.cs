using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArrayList<int> list = new MyArrayList<int>(3);
            list.addAll(new int[6] {12, 3, 4, 5, 6, 2});
            Console.WriteLine($"Has massive 3 - {list.contains(3)}");
            list.set(4, 8);
            list.remove(3);
            Console.WriteLine(list.isEmpty());
            for(int i = 0; i < list.getSize(); i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.ReadLine();
        }
    }
}
