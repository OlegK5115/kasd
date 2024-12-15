using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace task14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyArrayDeque<int> myArrayDeque = new MyArrayDeque<int>();
            myArrayDeque.add_all(new int[] { 5, 7, 9, 11 });
            myArrayDeque.add(8);

            Console.WriteLine(myArrayDeque.pop());
            Console.WriteLine(myArrayDeque.pop());
            Console.WriteLine(myArrayDeque.getsize());
            Console.WriteLine(myArrayDeque.get_first());
            Console.WriteLine(myArrayDeque.get_last());

            myArrayDeque.add_first(13);
            Console.WriteLine(myArrayDeque.get_first());
            Console.WriteLine(myArrayDeque.getsize());

            Console.ReadLine();
        }
    }
}