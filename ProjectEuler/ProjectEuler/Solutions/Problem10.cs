using MathLibrary.Utilities;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Solutions
{
    // The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17. Find the sum of all the primes below two million.
    public class Problem10 : ILongProblem
    {
        private const long TARGET = 2000000;

        public long Solve()
        {
            return Utility.SumPrimeNumbers(TARGET);
        }
    }
}
