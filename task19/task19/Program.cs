using System;
using System.IO;
using System.Text.RegularExpressions;

namespace task19
{
    class Program
    {
        static void Main()
        {
            try
            {
                const string file = "../../input.txt";
                StreamReader stream_reader = new StreamReader(file);

                MyHashMap<string, int> tags = new MyHashMap<string, int>();
                MatchCollection match_coll;

                Regex regex = new Regex(@"</?[A-Za-z][0-9A-Za-z]*>");
                string line, tag;

                while (!stream_reader.EndOfStream)
                {
                    line = stream_reader.ReadLine();
                    match_coll = regex.Matches(line);

                    foreach (Match match in match_coll)
                    {
                        tag = match.Value.ToLower();
                        if (tag.Contains("/")) { tag = tag.Remove(1, 1); }
                        if (!tags.contains_key(tag))
                        {
                            tags.put(tag, 1);
                            continue;
                        }
                        tags.put(tag, tags.get(tag) + 1);
                    }
                }
                tags.print();
                stream_reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();
        }
    }
}
