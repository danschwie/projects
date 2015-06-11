using MathLibrary.Utilities;
using ProjectEuler.Interfaces;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System;

namespace ProjectEuler.Solutions
{
    public class Problem24 : ILongProblem
    {
        private Dictionary<char, int> _dictionary;

        public long Solve()
        {
            var runningTotal = 0;

            var numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            for (int i = 0; i < 10; i++)
            {

                PrintList(numbers);
            }

            return runningTotal;
        }

        private void PrintList(List<int> l)
        {
            var sb = new StringBuilder();

            foreach (var n in l)
            {
                sb.Append(n.ToString());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
