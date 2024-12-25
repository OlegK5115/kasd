using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace task25
{
    class Program
    {
        public static void Main()
        {
            string input = "../../input.txt";
            List<string> linesWithSpaces = ReadLinesWithSpaces(input);

            // печать элем-в множества
            foreach (var line in linesWithSpaces.ToArray()) { Console.WriteLine(line); }

            Console.ReadLine();
        }

        private static List<string> ReadLinesWithSpaces(string filePath)
        {
            var input = new MyHashSet<string>();
            // чтение строк файла
            foreach (var line in File.ReadLines(filePath))
            {
                if (line.Contains(' ')) // проверка наличие пробелов
                {
                    input.Add(line.Trim());
                }
            }

            var linesWithSpaces = input.ToArray().ToList();
            // сортировка строк по наим. слову строки 
            linesWithSpaces.Sort((line1, line2) => CompareLines(line1, line2));

            return linesWithSpaces;
        }

        private static int CompareLines(string line1, string line2)
        {
            // разделяем строки на слова и сортируем их по длине
            var words1 = line1.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(word => word.Length).ToList();
            var words2 = line2.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(word => word.Length).ToList();

            int minCount = Math.Min(words1.Count, words2.Count);

            // сравниваем слова, пока найдем несовпадение
            for (int i = 0; i < minCount; i++)
            {
                int lengthComparison = words1[i].Length.CompareTo(words2[i].Length);
                if (lengthComparison != 0)
                {
                    return lengthComparison;
                }
            }

            // если одна строка имеет меньше слов, то она "меньше"
            return words1.Count.CompareTo(words2.Count);
        }
    }
}
