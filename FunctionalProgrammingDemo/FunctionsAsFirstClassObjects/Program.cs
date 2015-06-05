using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionsAsFirstClassObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //DemoFunctionPassing();
            
            DemoFunctionReturning();
        }

        static void DemoFunctionPassing()
        {
            string[] arr = GetStringArray();

            StringArrayOperation(s => s.ToUpper(), arr);
            Console.WriteLine();

            StringArrayOperation(s => s + s, arr);
            Console.WriteLine();

            StringArrayOperation(Reverse, arr);
            Console.WriteLine();
        }

        static void DemoFunctionReturning()
        {
            Func<int, int> square = GetFunction("square");
            Console.WriteLine(square(5));
            Console.WriteLine();

            Func<int, int> negate = GetFunction("negate");
            Console.WriteLine(negate(5));
            Console.WriteLine();

            Func<int, int> increment = GetFunction("increment");
            Console.WriteLine(increment(5));
            Console.WriteLine();
        }

        /// <summary>
        /// Higher-order function returns a function that takes a single integer parameter and returns an integer.
        /// </summary>
        /// <param name="functionName">Name of the function to return.</param>
        static Func<int, int> GetFunction(string functionName)
        {
            switch (functionName)
            {
                case "square":
                    return x => x * x;
                case "negate":
                    return x => -x;
                case "increment":
                    return x => ++x;
                default:
                    return x => x;
            }
        }

        /// <summary>
        /// Higher-order function takes a function and a string array and prints the results of applying the function to each item in the array.
        /// </summary>
        /// <param name="f">A function that takes a single string and returns a string.</param>
        /// <param name="l">An array of strings.</param>
        static void StringArrayOperation(Func<string, string> f, string[] l)
        {
            foreach (string s in l)
            {
                Console.WriteLine(f(s));
            }
        }

        static string Reverse(string s)
        {
            return s.Length == 0 ? s : Reverse(s.Substring(1, s.Length - 1)) + s.Substring(0, 1);
        }

        static string[] GetStringArray()
        {
            string[] italianFoods = new string[10];

            italianFoods[0] = "Lasagna";
            italianFoods[1] = "Rissoto";
            italianFoods[2] = "Pizza";
            italianFoods[3] = "Prosciutto";
            italianFoods[4] = "Polenta";
            italianFoods[5] = "Parmigiano-Reggiano";
            italianFoods[6] = "Radicchio";
            italianFoods[7] = "Ravioli";
            italianFoods[8] = "Minestrone";
            italianFoods[9] = "Chianti";

            return italianFoods;
        }
    }
}
