using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        private static string findTag(string s, ref int index)
        {
            string res = "" + s[index++];
            if (s[index] == '/') { res += s[index++]; }
            if ((s[index] < 65 || s[index] > 90) &&
                (s[index] < 97 || s[index] > 122))
            {
                return "";
            }

            while(index < s.Length)
            {
                if ((s[index] != '>') &&
                    (s[index] < 65 || s[index] > 90) &&
                    (s[index] < 97 || s[index] > 122) &&
                    (s[index] < 48 || s[index] > 57))
                {
                    return "";
                }
                res += s[index++];
                if (res[res.Length-1] == '>') { return res; }
            }


            return "";
        }

        private static bool EqualTags(string tag1, string tag2)
        {
            int index1 = 1, index2 = 1;
            if (tag1[index1] == '/') { index1++; }
            if (tag2[index2] == '/') { index2++; }

            if (tag1.Length - index1 != tag2.Length - index2) { return false; }
            while(index1 < tag1.Length)
            {
                if ((tag1[index1] != tag2[index2]) && Math.Abs(tag1[index1]-tag2[index2]) != 32)
                {
                    return false;
                }
                index1++;
                index2++;
            }

            return true;
        }
        static void Main(string[] args)
        {
            MyArrayList<string> list = new MyArrayList<string>();

            StreamReader r = new StreamReader("../../input.txt");
            while(r.Peek() != -1)
            {
                string[] s = Convert.ToString(r.ReadLine()).Split(' ');
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = 0; j < s[i].Length; j++)
                    {
                        if (s[i][j] == '<')
                        {
                            string tag = findTag(s[i], ref j);
                            if (tag != "")
                            {
                                list.add(tag);
                            }
                        }
                    }
                }
            }
            r.Close();

            for (int i = 0; i < list.getSize(); i++)
            {
                for (int j = i+1; j < list.getSize(); j++)
                {
                    if (EqualTags(list[i], list[j]))
                    {
                        list.remove(list[j]);
                    }
                }
            }
            for(int i = 0; i < list.getSize(); i++)
            {
                Console.Write(list[i]);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
