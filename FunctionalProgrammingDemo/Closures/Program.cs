using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Closures
{
    class Program
    {
        static void Main(string[] args)
        {
            int y = 10; // y is local to Main method

            // The value of x will be supplied later, but the value of y is 'set'/closed here.
            var functionSnapshot = new Func<int, int>(x => x + y);

            y = 20;

            // Passing the set/closed function to another function to use. 100 will be the value for x in the closed function.
            IntOperation(functionSnapshot, 230); 

            // Execute a function that is closed over a variable that is local to the GetClosure() method.
           Console.WriteLine(GetClosure()(200));
        }

        /// <summary>
        /// Function that takes a function f and an integer x and prints out the result of f(x).
        /// </summary>
        /// <param name="f">Any function that takes a single integer parameter and returns an integer.</param>
        /// <param name="x">An integer value that will be passed as a parameter to f.</param>
        static void IntOperation(Func<int, int> f, int x)
        {
            Console.WriteLine(f(x));   
        }

        /// <summary>
        /// Trivial function returns a doubling function that is "closed" over a local variable.
        /// </summary>
        /// <returns>A doubling function that is "closed" over a local variable.</returns>
        static Func<int, int> GetClosure()
        {
            int multiplier = 2; // multiplier is local to GetClosure method

            return x => x * multiplier;
        }
    }
}
