using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MathLibrary.Utilities
{
    public class Utility
    {
        public delegate List<long> LongListDelegate(long l);

        #region - Prime Number Methods -

        /// <summary>
        /// Determines whether a give 64 bit integer is prime or not.
        /// </summary>
        /// <param name="n">A 64 bit integer.</param>
        /// <returns>True if n is prime, else false;</returns>
        public static bool IsPrime(long n)
        {
            // 1 is not prime
            if (n == 1)
            {
                return false;
            }
            // 2 and 3 are prime
            if (n < 4)
            {
                return true;
            }
            // No even numbers except for 2 are prime
            if (n % 2 == 0)
            {
                return false;
            }
            // 5 and 7 are prime
            if (n < 9)
            {
                return true;
            }
            if (n % 3 == 0)
            {
                return false;
            }

            var floor = Convert.ToInt64(Math.Floor(Math.Sqrt(n)));
            var i = 5;

            while (i <= floor)
            {
                if (n % i == 0)
                {
                    return false;
                }
                if (n % (i + 2) == 0)
                {
                    return false;
                }

                i += 6;
            }

            return true;
        }

        /// <summary>
        /// Determines whether a give 64 bit integer is composite or not.
        /// </summary>
        /// <param name="n">A 64 bit integer.</param>
        /// <returns>True if n is composite, else false;</returns>
        public static bool IsComposite(long n)
        {
            return !IsPrime(n) && (n != 1);
        }

        /// <summary>
        /// Gets the prime factors of a specified target.
        /// </summary>
        /// <param name="target">A positive integer.</param>
        /// <returns>The prime factors of target.</returns>
        public static List<long> PrimeFactors(long target)
        {
            if (target == 1 || Utility.IsPrime(target))
            {
                return null;
            }

            List<long> candidates = PrimeNumbers(target);
            List<long> primeFactors = new List<long>();

            bool completed = false;
            int index = 0;

            while (!completed)
            {
                if (target % candidates[index] == 0)
                {
                    target /= candidates[index];

                    primeFactors.Add(candidates[index]);

                    if (Utility.IsPrime(target))
                    {
                        primeFactors.Add(target);
                        completed = true;
                    }
                }
                else
                {
                    index++;
                }
            }

            return primeFactors;
        }

        /// <summary>
        /// Sieve of Eratosthenes. Finds all prime numbers less than or equal to a specified target.
        /// </summary>
        /// <param name="target">A positive integer.</param>
        /// <returns>A list of all prime numbers less than or equal to target.</returns>
        public static List<long> PrimeNumbers(long target)
        {
            if (target > 1)
            {
                List<long> primeNumbers = new List<long>();

                for (long i = 2; i <= target; i++)
                {
                    primeNumbers.Add(i);
                }

                int index = 0;

                while (primeNumbers[index] < Convert.ToInt64(Math.Ceiling(Math.Sqrt(target))))
                {
                    primeNumbers.RemoveAll(l => (l % primeNumbers[index] == 0 && l != primeNumbers[index]));
                    index++;
                }

                return primeNumbers;
            }

            return null;
        }

        /// <summary>
        /// Gets the smallest factor of a specified target.
        /// </summary>
        /// <param name="target">A positive integer.</param>
        /// <returns>The smallest factor of target.</returns>
        public static long SmallestPrimeFactor(long target)
        {
            return PrimeFactors(target).Min();
        }

        /// <summary>
        /// Gets the largest prime factor of a specified target.
        /// </summary>
        /// <param name="target">A positive integer.</param>
        /// <returns>The largest prime factor of target.</returns>
        public static long LargestPrimeFactor(long target)
        {
            return PrimeFactors(target).Max();
        }

        /// <summary>
        /// Gets the number of prime factors for a given target.
        /// </summary>
        /// <param name="target">A positive integer.</param>
        /// <returns>The number of prime factors for target.</returns>
        public static long CountPrimeFactors(long target)
        {
            return PrimeFactors(target).Count();
        }

        /// <summary>
        /// Gets the sum of the prime factors for a given target.
        /// </summary>
        /// <param name="target">A positive integer.</param>
        /// <returns>The sum of the prime factors for target.</returns>
        public static long SumPrimeFactors(long target)
        {
            List<long> l = PrimeFactors(target);
            return PrimeFactors(target).Sum();
        }

        /// <summary>
        /// Gets the number of prime numbers less than or equal to a given target.
        /// </summary>
        /// <param name="target">A positive integer.</param>
        /// <returns>The number of prime numbers less than or equal to target.</returns>
        public static long CountPrimeNumbers(long target)
        {
            return PrimeNumbers(target).Count();
        }

        /// <summary>
        /// Gets the sum of the prime numbers less than or equal to a given target.
        /// </summary>
        /// <param name="target">A positive integer.</param>
        /// <returns>The sum of the prime numbers less than or equal to target.</returns>
        public static long SumPrimeNumbers(long target)
        {
            return PrimeNumbers(target).Sum();
        }

        #endregion

        #region - Factoring Methods -

        public static List<long> AllFactors(long target)
        {
            List<long> factors = new List<long>();
            int divisor = 2;
            long tempTarget = 0;

            while (divisor <= target / 2)
            {
                tempTarget = target;

                if (tempTarget % divisor == 0)
                {
                    if (!factors.Contains(divisor))
                    {
                        factors.Add(divisor);
                    }

                    while (tempTarget % divisor == 0)
                    {
                        long newFactor = tempTarget / divisor;

                        if (!factors.Contains(newFactor))
                        {
                            factors.Add(newFactor);
                        }

                        tempTarget /= divisor;
                    }
                }

                divisor++;
            }

            if (!factors.Contains(1))
            {
                factors.Add(1);
            }

            factors.Add(target);

            factors.Sort();

            return factors;
        }

        public static int NumFactors(long n)
        {
            if (IsComposite(n))
            {
                List<long> primeFactors = PrimeFactors(n);
                List<long> distinctPrimeFactors = primeFactors.Distinct().ToList();
                int numFactors = 1;

                foreach (long target in distinctPrimeFactors)
                {
                    int count = (from primeFactor in primeFactors where primeFactor == target select primeFactor).Count();
                    numFactors *= (count + 1);
                }

                return numFactors;
            }
            else
            {
                return n == 1 ? 1 : 2;
            }
        }

        public static List<long> ProperFactors(long n)
        {
            var factors = AllFactors(n);
            factors.Remove(n);
            return factors;
        }

        public static int MaxNumberOfFactors(long floor, long ceiling)
        {
            if (floor >= ceiling)
            {
                throw new Exception("floor must be less than ceiling");
            }

            int maxNumberOfFactors = 0;

            for (long i = floor; i <= ceiling; i++)
            {
                int numberOfFactors = NumFactors(i);

                if (numberOfFactors > maxNumberOfFactors)
                {
                    maxNumberOfFactors = numberOfFactors;
                }
            }

            return maxNumberOfFactors;
        } 

        #endregion

        public static BigInt BruteForceFactorial(int n)
        {
            var factorial = new BigInt(2);
            var tempFactorial = factorial;

            var counter = 2;

            while (counter < n)
            {
                int nextNumber = counter + 1;

                for (int i = 1; i < nextNumber; i++)
                {
                    factorial += tempFactorial;
                }

                tempFactorial = factorial;
                counter++;
            }

            return factorial;
        }

        public static BigInteger BruteForceFactorial(BigInteger n)
        {
            var factorial = new BigInteger(2);
            var tempFactorial = factorial;

            var counter = 2;

            while (counter < n)
            {
                int nextNumber = counter + 1;

                for (int i = 1; i < nextNumber; i++)
                {
                    factorial += tempFactorial;
                }

                tempFactorial = factorial;
                counter++;
            }

            return factorial;
        }

        public static List<string> GetPermutations(string s)
        {
            var distinctCharList = (from c in s.ToCharArray().ToList() select c).Distinct().ToList();
            //var permutationList = new List<string>(Math.f);
            var sb = new StringBuilder(s.Length);

            return null;
        }

        public static bool IsPalindrome(int n)
        {
            return IsPalindrome(n.ToString());
        }

        public static bool IsPalindrome(long n)
        {
            return IsPalindrome(n.ToString());
        }

        public static bool IsPalindrome(string s)
        {
            if (s.Length <= 1)
            {
                return true;
            }
            else
            {
                if (s[0] == s[s.Length - 1])
                {
                    s = s.Remove(0, 1);
                    s = s.Remove(s.Length - 1, 1);
                    return IsPalindrome(s);
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsPerfectSquare(int n)
        {
            return !Math.Sqrt(n).ToString().Contains('.');
        }

        public static long RecursiveFactorial(int n)
        {
            if (n == 1)
            {
                return n;
            }
            else
            {
                return n * RecursiveFactorial(n - 1);
            }
        }

        public static int Square(int n)
        {
            return n * n;
        }

        public static long TriangleNumber(int n)
        {
            return ((n * n) + n) / 2;
        }

        #region - ToString Methods -

        public static string ToString(LongListDelegate lld, long target)
        {
            return ToString(lld, target, "");
        }

        public static string ToString(LongListDelegate lld, long target, string headerText)
        {
            var delimiter = "************************************************************";
            var longs = lld(target);
            var sb = new StringBuilder(string.Format("{0}\n", delimiter));
            sb.Append(string.Format("{0}\n", headerText));

            foreach (var l in longs)
            {
                sb.Append(string.Format("[{0}] ", l));
            }

            sb.Remove(sb.Length - 1, 1);

            sb.Append(string.Format("\n{0}\n", delimiter));

            return sb.ToString();
        } 

        #endregion
    }
}
