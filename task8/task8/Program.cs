using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<string> stack = new MyStack<string>();

            stack.push("Hello");
            stack.push("Oleg");
            stack.pop();

            Console.WriteLine($"{stack.peek()}");
            Console.ReadLine();
        }
    }
}
