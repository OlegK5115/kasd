using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("../../file.txt");
            
            int n = Convert.ToInt32(streamReader.ReadLine());

            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] matinarray = streamReader.ReadLine().Split();
                for (int k = 0; k < matinarray.Length; k++)
                {
                    matrix[i, k] = Convert.ToInt32(matinarray[k]);
                }
            }

            int[] vector = new int[n];
            string[] vecinarray = streamReader.ReadLine().Split();
            for (int k = 0; k < vecinarray.Length; k++)
            {
                vector[k] = Convert.ToInt32(vecinarray[k]);
            }

            streamReader.Close();

            bool check = true;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        check = false;
                        break;
                    }
                }
            }

            if (!check)
            {
                Console.WriteLine("Error: matrix is not symmetrical");
                Console.ReadLine();
                return;
            }

            int answer = 0;

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += matrix[i, j] * vector[j];
                }

                answer += sum*vector[i];
            }

            Console.WriteLine(Math.Sqrt(answer));

            Console.ReadLine();
        }
    }
}
