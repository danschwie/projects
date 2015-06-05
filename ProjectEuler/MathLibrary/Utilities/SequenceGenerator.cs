using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary.Utilities
{
    public static class SequenceGenerator
    {
        public static BigInt GetFibonacciTermValue(int index)
        {
            BigInt n1 = 1;
            BigInt n2 = 1;
            BigInt term = 1;

            for (int i = 1; i <= index; i++)
            {
                if (i > 2)
                {
                    term = n1 + n2;
                    n1 = n2;
                    n2 = term;
                }
            }

            return term;
        }

        public static void PrintFibonacci(int index)
        {
            for (int i = 1; i <= index; i++)
            {
                Console.WriteLine("F{0} = {1}", i, GetFibonacciTermValue(i));
            }
        }
    }
}
