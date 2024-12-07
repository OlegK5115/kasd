using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass1 = { 9, 6, 1, 3, 0};
            MyHeap<int> myHeap = new MyHeap<int>(mass1);
            myHeap.get_maxvalue();
            for (int i = 0; i < myHeap.size(); i++) { Console.Write($"{myHeap[i]} "); }
            Console.WriteLine(myHeap.pop_maxvalue());
            for (int i = 0; i < myHeap.size(); i++) { Console.Write($"{myHeap[i]} "); }

            int[] mass2 = { 9, 3, 8 };
            MyHeap<int> myHeap2 = new MyHeap<int>(mass2);
            myHeap.merge(myHeap2);
            for (int i = 0; i < myHeap.size(); i++) { Console.Write($"{myHeap[i]} "); }
            Console.WriteLine(myHeap.pop_maxvalue());
            for (int i = 0; i < myHeap.size(); i++) { Console.Write($"{myHeap[i]} "); }

            Console.ReadLine();
        }
    }
}
