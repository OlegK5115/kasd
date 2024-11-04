using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    internal class Program
    {
        static bool check_number(char c)
        {
            if (c >= 48 && c < 58) { return true; }
            return false;
        }

        static void searchNotIP(string s, ref int index)
        {
            while (index < s.Length)
            {
                if (s[index] != '.' && !check_number(s[index])) { break; }
                if (index > 0 && s[index - 1] == '.' && s[index] == '.') { break; }

                index++;
            }
        }

        static string searchIP(string s, ref int index)
        {
            int[] nums = { 0, 0, 0, 0 };
            int num_count = 0;
            bool check = false;

            int i = index;
            while (i < s.Length) {
                if (check_number(s[i]))
                {
                    if (num_count >= nums.Length)
                    {
                        searchNotIP(s, ref index);
                        return "";
                    }

                    nums[num_count] *= 10;
                    nums[num_count] += s[i] - 48;
                    check = true;

                    if (nums[num_count] > 255)
                    {
                        searchNotIP(s, ref index);
                        return "";
                    }
                }
                else if (s[i] == '.' && !(i == s.Length-1 || s[i + 1] == '.'))
                {
                    num_count++;
                    index = i + 1;
                    check = false;
                }
                else
                {
                    i++;
                    break;
                }

                i++;
            }

            index = i;

            if (num_count == nums.Length - 1 && check)
            {
                return $"{nums[0]}.{nums[1]}.{nums[2]}.{nums[3]}";
            }

            return "";
        }

        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("../../input.txt");

            MyVector<string> s = new MyVector<string>();

            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                if (line == null) { continue; }
                string[] parts = line.Split();
                if (parts.Length == 0)
                {
                    continue;
                }
                for (int i = 0; i < parts.Length; i++)
                {
                    string part = parts[i];
                    int ind = 0;
                    while (ind < part.Length)
                    {
                        if (check_number(part[ind]))
                        {
                            string ip = searchIP(part, ref ind);
                            if (ip != "")
                            {
                                s.add(ip);
                            }
                        }
                        else { ind++; }
                    }
                }
            }

            r.Close();

            StreamWriter w = new StreamWriter("../../output.txt");
            for (int i = 0; i < s.size(); i++)
            {
                w.WriteLine(s.get(i));
            }
            w.Close();
        }
    }
}
