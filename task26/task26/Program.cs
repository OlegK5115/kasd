using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace task26
{
    class Program
    {
        public static void Main()
        {
            string inputFilePath = "../../input.txt";

            MyHashSet<string> uniqueWords = new MyHashSet<string>();
            FindUniqueWords(inputFilePath, uniqueWords);

            foreach (var word in uniqueWords.ToArray())
            {
                Console.WriteLine(word);
            }

            Console.ReadLine();
        }

        private static void FindUniqueWords(string filePath, MyHashSet<string> wordSet)
        {
            var wordRegex = new Regex("[a-zA-Z]+");

            foreach (var line in File.ReadLines(filePath))
            {
                var matches = wordRegex.Matches(line);

                foreach (Match match in matches)
                {
                    string word = match.Value.ToLower();
                    wordSet.Add(word);
                }
            }
        }
    }
}
