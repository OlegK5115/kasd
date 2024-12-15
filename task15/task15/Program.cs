using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task15
{
    internal class Program
    {
        static int count(string s, MyArrayDeque<char> alph)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (alph.contains(s[i])) { count++; }
            }
            
            return count;
        }
        static int count(string s, char sym)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == sym) { count++; }
            }
                    
            return count;
        }
        static void Main()
        {
            try
            {
                Console.Write("n - ");
                int n = int.Parse(Console.ReadLine());

                string file1 = "../../input.txt", file2 = "../../sorted.txt";
                StreamReader input = new StreamReader(file1);

                MyArrayDeque<string> deque = new MyArrayDeque<string>();
                MyArrayDeque<char> digits = new MyArrayDeque<char>();
                for (int i = 0; i <= 9; i++) {
                    char.TryParse(i.ToString(), out char c);
                    digits.push(c);
                }

                string line;
                int first_cnt = 0;
                if (!input.EndOfStream)
                {
                    line = input.ReadLine();
                    deque.push(line);
                    first_cnt = count(line, digits);
                }

                int dcount;
                while (!input.EndOfStream)
                {
                    line = input.ReadLine();
                    dcount = count(line, digits);
                    if (dcount > first_cnt) { deque.add_last(line); }
                    else
                    {
                        deque.add_first(line);
                        first_cnt = dcount;
                    }
                }

                StreamWriter sorted = new StreamWriter(file2);
                string[] mass = deque.to_array();
                for (int i = 0; i < mass.Length; i++)
                {
                    sorted.Write(mass[i] + "\n");
                }
                for (int i = 0; i < mass.Length; i++)
                {
                    if (count(mass[i], ' ') > n)
                    {
                        deque.remove(mass[i]);
                    }
                }
                for (int i = 0; i < deque.getsize(); i++)
                {
                    Console.WriteLine($"{deque[i]} ");
                }
                Console.WriteLine();

                input.Close();
                sorted.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}