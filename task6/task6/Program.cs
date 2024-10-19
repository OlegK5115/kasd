using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyVector<int> vector = new MyVector<int>(1, 1);
            vector.add(1);
            vector.add(2);
            vector.add(3);
            vector.add(4);
            vector.add(5);
            vector.add(6);
            vector.removeRange(2, 5);
            for (int i = 0; i < vector.size(); i++)
            {
                Console.WriteLine(vector.get(i));
            }
            Console.ReadLine();
        }
    }
}
