using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


namespace task20
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string inputFilePath = Path.Combine(dir, "input.txt");
            string outputFilePath = Path.Combine(dir, "results.txt");

            string pattern = @"(?<type>[a-zA-Z_][a-zA-Z0-9_]*)\s+(?<name>[a-zA-Z_][a-zA-Z0-9_]*)\s*=\s*(?<value>\d+)\s*;";
            MyHashMap<string, Variable> variabelsMap = new MyHashMap<string, Variable>();
            var errors = new List<string>();


            string variablesFile = File.ReadAllText(inputFilePath);
            variablesFile = variablesFile.Replace("\r", "").Replace("\n", " ");

            MatchCollection matches = Regex.Matches(variablesFile, pattern);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    string typeStr = match.Groups["type"].Value;
                    string name = match.Groups["name"].Value;
                    string value = match.Groups["value"].Value;


                    if (!Enum.TryParse(typeStr, true, out Type type))
                    {
                        errors.Add($"wrong type: {typeStr} for var {name}.");
                        continue;
                    }
                    if (variabelsMap.ContainsKey(name))
                    {
                        errors.Add($"same var: {name}");
                        continue;
                    }

                    variabelsMap.Put(name, new Variable(type, value));
                }

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var entry in variabelsMap.EntrySet())
                    {
                        writer.WriteLine($"{entry.Value.Type} => {entry.Key}({entry.Value.Value})");
                    }

                    writer.WriteLine("\nerror:");
                    foreach (string error in errors)
                    {
                        writer.WriteLine(error);
                    }
                }

                Console.WriteLine($"results in {outputFilePath}");
            }
            else
            {
                Console.WriteLine("hasn't vars");
            }
        }
    }
}
