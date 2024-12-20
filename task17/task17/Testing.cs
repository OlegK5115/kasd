using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task17
{
    internal class Testing
    {

        MyArrayList<int> arrayList;
        MyLinkedList<int> linkedList;
        int minSize = 100;
        int maxSize = 100000 + 1;

        public Testing()
        {
            arrayList = new MyArrayList<int>();
            linkedList = new MyLinkedList<int>();
        }

        public double[] TestAddArray()
        {
            double[] time = new double[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int i = 0; i != 20; i++)
                {
                    sw.Start();
                    for (int j = 0; j != n; j++)
                    {
                        arrayList.Add(1);
                    }
                    sw.Stop();
                    if (i != 19)
                        linkedList.clear();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public double[] TestAddLinked()
        {
            double[] time = new double[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        linkedList.add(1);
                    }
                    sw.Stop();
                    if (a != 19)
                        linkedList.clear();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }

        public double[] TestGetArray()
        {
            TestAddArray();

            double[] time = new double[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        var c = arrayList[i];
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public double[] TestGetLinked()
        {
            TestAddLinked();

            double[] time = new double[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        linkedList.get(i);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public double[] TestSetArray()
        {
            double[] time = new double[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        arrayList[i] = 2;
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public double[] TestSetLinked()
        {
            double[] time = new double[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        linkedList.set(i, 2);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public double[] TestAddValueArray()
        {
            double[] time = new double[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;
            arrayList.Clear();

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        arrayList.Add(3);
                    }
                    sw.Stop();
                    if (a != 19)
                        linkedList.clear();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public double[] TestAddValueLinked()
        {
            double[] time = new double[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;
            linkedList.clear();

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        linkedList.add(i, 3);
                    }
                    sw.Stop();
                    if (a != 19)
                        linkedList.clear();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }

        public double[] TestRemoveArray()
        {
            TestAddArray();

            double[] time = new double[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {
                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        arrayList.Remove(i);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
        public double[] TestRemoveLinked()
        {
            TestAddLinked();

            double[] time = new double[4];
            Stopwatch sw = new Stopwatch();
            int index = 0;

            for (int n = minSize; n < maxSize; n *= 10)
            {
                for (int a = 0; a != 20; a++)
                {

                    sw.Start();
                    for (int i = 0; i != n; i++)
                    {
                        linkedList.remove(i);
                    }
                    sw.Stop();
                    time[index] = sw.ElapsedMilliseconds;
                }
                time[index] /= 20;
                index++;
            }
            return time;
        }
    }
}
