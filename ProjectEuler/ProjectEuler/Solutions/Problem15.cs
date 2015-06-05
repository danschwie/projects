using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Interfaces;
using MathLibrary.Utilities;
using MathLibrary;
using System.Numerics;

namespace ProjectEuler.Solutions
{
    public class Problem15 : ILongProblem
    {
        public long Solve()
        {
            BigInteger n = 20;

            BigInteger numCombinations = Utility.BruteForceFactorial(2 * n) / (Utility.BruteForceFactorial(n) * Utility.BruteForceFactorial(n));

            return (Int64)numCombinations;
        }
    }
}
