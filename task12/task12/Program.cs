using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "../../log.txt";
            try
            {
                StreamWriter streamWriter = new StreamWriter(file);
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(n);

                MyPriorityQueue<Request> queue = new MyPriorityQueue<Request>();
                queue.comparator_set(Comparer<Request>.Create(Comparison));

                Random random = new Random();
                Stopwatch stopwatch = new Stopwatch();
                Tuple[] times = new Tuple[n * 10 + 1];

                Request req, last_req;
                Tuple time;
                int m, k = 1;
                stopwatch.Start();
                for (int i = 1; i <= n; i++)
                {
                    m = random.Next(1, 11);
                    for (int j = 1; j <= m; j++)
                    {
                        req = new Request(random.Next(1, 6), k, i);
                        queue.add(req);
                        time = new Tuple(stopwatch.Elapsed.TotalMilliseconds, req.priority, req.number, req.step);
                        times[k] = time;
                        streamWriter.Write($"add {req.number} {req.priority} {req.step}\n");
                        k++;
                    }
                    last_req = queue.Poll();
                    double waitingTime = stopwatch.Elapsed.TotalMilliseconds - times[last_req.number].time;
                    time = new Tuple(waitingTime, last_req.priority, last_req.number, last_req.step);
                    times[last_req.number] = time;
                    streamWriter.Write($"remove {last_req.number} {last_req.priority} {last_req.step}\n");
                }

                while (!queue.is_empty())
                {
                    last_req = queue.Poll();
                    double waitingTime = stopwatch.Elapsed.TotalMilliseconds - times[last_req.number].time;
                    time = new Tuple(waitingTime, last_req.priority, last_req.number, last_req.step);
                    times[last_req.number] = time;
                    streamWriter.Write($"remove " + $"{last_req.number} " + $"{last_req.priority} " + $"{last_req.step}\n");
                }
                stopwatch.Stop();

                int max_ind = 1;
                for (int i = 2; i < times.Length; i++)
                {
                    if (times[i].time > times[max_ind].time) { max_ind = i; }
                }
                    
                Console.Write("max time -- " + times[max_ind].time);
                Console.WriteLine();
                Console.Write("num -- " + times[max_ind].number);
                Console.WriteLine();
                Console.Write("prior -- " + times[max_ind].priority);
                Console.WriteLine();
                Console.Write("iter -- " + times[max_ind].step);
                Console.WriteLine();

                streamWriter.Close();

                Console.ReadLine();
            }
            catch (Exception exep) { Console.WriteLine(exep.ToString()); }
        }
        static int Comparison(Request request1, Request request2)
        {
            return request1.priority - request2.priority;
        }
    }
}