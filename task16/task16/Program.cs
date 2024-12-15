using System;

namespace task16
{
    internal class Program
    {
        static void Main()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.add(0, 1);
            list.add(1, 2);
            list.add(2, 3);
            list.print();

            int[] array = { 10, 20, 30 };
            list.add_all(1, array);
            list.add_right(20);
            list.add_right(40);
            list.add_right(20);
            list.add_right(50);
            list.print();

            list.remove_left_occurrence(20);
            list.print();

            list.remove_right_occurrence(20);
            list.print();

            Console.ReadLine();
        }
    }
}