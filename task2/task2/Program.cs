using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace task2
{

    struct Complex
    {
        double x;
        double y;

        public void create(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double search_module() { return Math.Sqrt(x*x + y*y); }

        public double search_arg() { return y/x; }

        public void out_x() { Console.WriteLine($"{x}"); }

        public void out_y() { Console.WriteLine($"{y}"); }

        public void out_all() { Console.WriteLine($"{x}, {y}"); }

        public static Complex addition(Complex num1, Complex num2)
        {
            Complex result = new Complex();
            result.x = num1.x + num2.x;
            result.y = num1.y + num2.y;
            return result;
        }

        public static Complex substraction(Complex num1, Complex num2)
        {
            Complex result = new Complex();
            result.x = num1.x - num2.x;
            result.y = num1.y - num2.y;
            return result;
        }
        
        public static Complex multiplic(Complex num1, Complex num2)
        {
            Complex result = new Complex();
            result.x = num1.x*num2.x - num1.y*num2.y;
            result.y = num1.y*num1.x + num1.x*num2.y;
            return result;
        }
        
        public static Complex division(Complex num1, Complex num2)
        {
            Complex result = new Complex();
            result.x = (num1.x*num2.x+num1.y*num2.y)/(num2.x*num2.x + num2.y*num2.y);
            result.y = (num2.x*num1.y-num1.x*num2.y)/(num2.x*num2.x + num2.y*num2.y);
            return result;
        }
    }

    internal class Program
    {
        static Complex enter_complex()
        {
            Complex complex = new Complex();
            Console.WriteLine("Enter x");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter y");
            int y = Convert.ToInt32(Console.ReadLine());
            complex.create(x, y);

            return complex;
        }

        static void Main(string[] args)
        {
            Complex complex = new Complex();

            Complex num1, num2, num3;
            while(true)
            {
                Console.WriteLine("Enter the command:");
                Console.WriteLine("a - create");
                Console.WriteLine("b - search_module");
                Console.WriteLine("c - search_arg");
                Console.WriteLine("d - out_x");
                Console.WriteLine("e - out_y");
                Console.WriteLine("f - out_all");
                Console.WriteLine("g - addition");
                Console.WriteLine("h - substraction");
                Console.WriteLine("i - multiplic");
                Console.WriteLine("j - division");
                Console.WriteLine("Q, q - exit");
                char command = Convert.ToChar(Console.ReadLine());

                switch (command)
                {
                    case 'a':
                        complex = Program.enter_complex();
                        break;
                    case 'b':
                        Console.WriteLine(complex.search_module());
                        break;
                    case 'c':
                        Console.WriteLine(complex.search_arg());
                        break;
                    case 'd':
                        complex.out_x();
                        break;
                    case 'e':
                        complex.out_y();
                        break;
                    case 'f':
                        complex.out_all();
                        break;
                    case 'g':
                        num1 = Program.enter_complex();
                        num2 = Program.enter_complex();

                        num3 = Complex.addition(num1, num2);
                        num3.out_all();
                        break;
                    case 'h':
                        num1 = Program.enter_complex();
                        num2 = Program.enter_complex();

                        num3 = Complex.substraction(num1, num2);
                        num3.out_all();
                        break;
                    case 'i':
                        num1 = Program.enter_complex();
                        num2 = Program.enter_complex();

                        num3 = Complex.multiplic(num1, num2);
                        num3.out_all();
                        break;
                    case 'j':
                        num1 = Program.enter_complex();
                        num2 = Program.enter_complex();

                        num3 = Complex.division(num1, num2);
                        num3.out_all();
                        break;
                    case 'Q':
                        return;
                    case 'q':
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
