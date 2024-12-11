using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mass = { 7, 3, 9, 2, 0, 18 };
            MyPriorityQueue<int> q = new MyPriorityQueue<int>(mass);
            q.element();
            for (int i = 0; i < q.getsize(); i++) { Console.Write(q[i] + " "); }
            Console.WriteLine();

            Console.WriteLine(q.Poll());
            for (int i = 0; i < q.getsize(); i++) { Console.Write(q[i] + " "); }
            Console.WriteLine();

            int[] mass2 = { 9, 3, 8, 2, 19 };
            MyPriorityQueue<int> q2 = new MyPriorityQueue<int>(mass2);
            MyPriorityQueue<int> q3 = new MyPriorityQueue<int>(q2);
            for (int i = 0; i < q.getsize(); i++) { Console.Write(q3[i] + " "); }
            Console.WriteLine();

            Console.WriteLine(q3.Poll());
            for (int i = 0; i < q.getsize(); i++) { Console.Write(q3[i] + " "); }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}