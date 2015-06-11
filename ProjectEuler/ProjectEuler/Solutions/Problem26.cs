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
    public class Problem26 : ILongProblem
    {
        private Dictionary<char, int> _dictionary;

        public long Solve()
        {
            var runningTotal = 0;

            for (decimal i = 2; i < 10; i++)
            {
                Console.WriteLine(1 / i);
            }

            return runningTotal;
        }
    }
}
