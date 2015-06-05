using MathLibrary.Utilities;
using ProjectEuler.Interfaces;
using MathLibrary;

namespace ProjectEuler.Solutions
{
    public class Problem20
    {
        private const int TARGET = 100;

        public BigInt Solve()
        {
            BigInt factorial = Utility.BruteForceFactorial(TARGET);
            return factorial.SumDigits();
        }
    }
}
