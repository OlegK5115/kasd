using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter math expression:");
            string exp = Console.ReadLine();

            Console.WriteLine("Enter variables");
            string ivars = Console.ReadLine();

            var vars = new Dictionary<string, double>();

            if (!string.IsNullOrEmpty(ivars))
            {
                var var_ass = ivars.Split(' ');
                foreach(var ass in var_ass)
                {
                    var parts = ass.Split('=');
                    if (parts.Length == 2 && double.TryParse(parts[1], out double value))
                    {
                        vars[parts[0]] = value;
                    }
                    else
                    {
                        Console.WriteLine($"ass - {ass}");
                    }
                }
            }

            exp = PolishCalculator.replace_vars(exp, vars);
            try
            {
                string polishexp = PolishCalculator.convert_to_postfix(exp);
                Console.WriteLine("Polish Cowpression");
                Console.WriteLine(polishexp);

                double res = PolishCalculator.calculate_polish(polishexp);
                Console.WriteLine($"Result - {res}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - {ex}");
            }

            Console.ReadLine();
        }
    }
    public static class PolishCalculator
    {
        private static readonly Regex reg_exp = new Regex(@"(\d+|\d+\.\d+|\(|\)|\+|\-|\*|\/|min|max|mod|abs|\^|sqrt|ln|log|sin|cos|tg)");

        private static readonly Dictionary<string, int> operation_prior = new Dictionary<string, int>
        {
            {"+", 1}, {"-", 1},
            {"*", 2}, {"/", 2},
            {"^", 3}, {"mod", 3}, {"min", 3}, {"max", 3},
            {"sqrt", 4}, {"log", 4}, {"ln", 4}, {"sin", 4}, {"cos", 4}, {"tg", 4}
        };

        private static bool is_number(string s)
        {
            return double.TryParse(s, out double num);
        }

        private static bool has_prior(string operation1, string operation2)
        {
            return operation_prior[operation1] > operation_prior[operation2];
        }

        private static double execute(string operation, double a, double b = 0)
        {
            switch (operation)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    if (b == 0) throw new DivideByZeroException("division by zero");
                    return a / b;
                case "^":
                    return Math.Pow(a, b);
                case "mod":
                    return a % b;
                case "min":
                    return Math.Min(a, b);
                case "max":
                    return Math.Max(a, b);
                case "sqrt":
                    if (a < 0) throw new InvalidOperationException("error: can't compute square of negative number.");
                    return Math.Sqrt(a);
                case "ln":
                    if (a <= 0) throw new InvalidOperationException("error: logarithm don't work with zero or negative values");
                    return Math.Log(a);
                case "log":
                    if (a <= 0) throw new InvalidOperationException("error: logarithm undefined with zero or negative values");
                    return Math.Log10(a);
                case "sin":
                    return Math.Sin(a);
                case "cos":
                    return Math.Cos(a);
                case "tg":
                    return Math.Tan(a);
                case "abs":
                    return Math.Abs(a);
                default:
                    throw new InvalidOperationException("unsupported operator");
            }
        }

        public static string convert_to_postfix(string exp, int prior = 0)
        {
            var output = "";
            var operations = new MyStack<string>();

            var mass = reg_exp.Matches(exp).Cast<Match>().Select(m => m.Value).ToArray();
            /* ищем все совпадения с рег. выражением */

            foreach (var s in mass)
            {
                if (is_number(s)) // число
                {
                    output += (s + " ");
                }
                else if (operation_prior.ContainsKey(s)) // операция
                {
                    if (!operations.isEmpty() && operations.peek() == "(") operations.push(s);
                    else
                    {
                        while (!operations.isEmpty() && has_prior(operations.peek(), s))
                        {
                            output += (operations.pop() + " ");
                        }
                        operations.push(s);
                    }
                }
                else if (s == "(") // скобка (
                {
                    operations.push(s);
                }
                else if (s == ")") // скобка )
                {
                    while (operations.peek() != "(")
                    {
                        output += (operations.pop() + " ");
                    }
                    operations.pop();
                }
            }

            while (!operations.isEmpty())
            {
                output += (operations.pop() + " ");
            }

            return output.ToString().Trim();
        }

        public static double calculate_polish(string expression)
        {
            var stack = new MyStack<double>();
            var mass = expression.Split(' ');

            foreach (var s in mass)
            {
                if (is_number(s)) // число
                {
                    stack.push(double.Parse(s));
                }
                else if (operation_prior.ContainsKey(s)) // операция
                {
                    if (s == "sqrt" || s == "ln" || s == "log" || s == "sin" || s == "cos" || s == "tan" || s == "abs")
                    {
                        var a = stack.pop();
                        stack.push(execute(s, a));
                    }
                    else
                    {
                        var b = stack.pop();
                        var a = stack.pop();
                        stack.push(execute(s, a, b));
                    }
                }
            }

            return stack.pop();
        }


        public static string replace_vars(string exp, Dictionary<string, double> vars)
        {
            foreach(var v in vars)
            {
                exp = exp.Replace(v.Key, v.Value.ToString());
            }
            return exp;
        }
    }
}
