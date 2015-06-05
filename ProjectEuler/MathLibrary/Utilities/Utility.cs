using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MathLibrary.Objects;
using System.Numerics;

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

        public static List<long> AllFactors(long target)
        {
            List<long> factors = new List<long>();
            int divisor = 2;
            long tempTarget = 0;

            while(divisor <= target / 2)
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

        public static string[] ArrayFromCommaDelimitedFile(string filePath)
        {
            StreamReader reader = File.OpenText(filePath);
            var s = reader.ReadToEnd();
            var arr = s.Split(new char[] { ',' });
            reader.Close();

            return arr;
        }

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

        public static Graph<int> MakeBinaryTreeFromFile(string filePath)
        {
            var line = "";
            var rows = new List<List<int>>();
            var vertices = new List<List<Vertex<int>>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var numbers = new List<int>(line.Split(' ').Select(i => Convert.ToInt32(i)));
                    vertices.Add((from n in numbers select new Vertex<int>(n)).ToList());
                }
            }

            var graph = new Graph<int>();
            var rowCount = 0;
            var cellCount = 0;

            foreach (var vertexRow in vertices)
            {
                cellCount = 0;

                foreach (Vertex<int> vertex in vertexRow)
                {
                    if (rowCount != vertices.Count - 1)
                    {
                        if (rowCount == 0)
                        {
                            vertex.HasParent = false;
                        }
                        else
                        {
                            vertex.HasParent = true;
                        }

                        vertex.IsLeaf = false;

                        var firstChild = vertices[rowCount + 1][cellCount];
                        var secondChild = vertices[rowCount + 1][cellCount + 1];

                        vertex.AddReachableVertex(firstChild);
                        vertex.AddReachableVertex(secondChild);
                    }
                    else
                    {
                        vertex.IsLeaf = true;
                        vertex.HasParent = true;
                    }

                    graph.Add(vertex);

                    cellCount++;
                }

                rowCount++;
            }

            return graph;
        }

        public static Graph<int> MakeSquareLattice(int numSquaresPerSide)
        {
            var graph = new Graph<int>();

            for (int i = 1; i <= numSquaresPerSide * numSquaresPerSide; i++)
            {
                var v = new Vertex<int>(i);
                graph.Add(v);
            }

            // Example of a 5 x 5 lattice. From s01, a move can be made to either s02 or s06;
            // s01  s02  s03  s04  s05
            // s06  s07  s08  s09  s10
            // s11  s12  s13  s14  s15
            // s16  s17  s18  s19  s20
            // s21  s22  s23  s24  s25
            foreach (Vertex<int> v in graph.Vertices)
            {
                // Only add an edge to an adjacent vertex if we are not on the right side of the lattice;
                if (v.Value % numSquaresPerSide != 0)
                {
                    var adjacentVertex = graph.Vertices.Where(i => i.Value == v.Value + 1).SingleOrDefault();
                    v.AddReachableVertex(adjacentVertex);
                }

                // Attempt to get a reference to the vertex directly below the current vertex. This reference will be null for 
                // vertices in the bottom row.
                var belowVertex = graph.Vertices.Where(i => i.Value == v.Value + numSquaresPerSide).SingleOrDefault();
                
                if (belowVertex != null)
                {
                    v.AddReachableVertex(belowVertex);
                }
            }

            return graph;
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

        /// <summary>
        /// Returns the number of distinct edges in a n x n grid.
        /// </summary>
        /// <param name="n">The root of the n x n grid.</param>
        /// <returns>The number of distinct edges in a n x n grid.</returns>
        public static int NumDistinctEdges(int n)
        {
            return (2 * n) + (2 * Square(n));
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

        public static long TriangleNumber(int n)
        {
            return ((n * n) + n) / 2;
        }

        public static int[,] TwoDArrayFromFile(string filePath)
        {
            var matrix = new int[20, 20];
            var reader = File.OpenText(filePath);
            var s = reader.ReadLine();
            var rowIndex = 0;

            while (s != null)
            {
                var arr = s.Split(new char[] { ' ' });

                for (int i = 0; i < arr.Length; i++)
                {
                    matrix[rowIndex, i] = arr[i].Substring(0, 1) == "0"
                      ? Convert.ToInt32(arr[i].Substring(1, 1))
                      : Convert.ToInt32(arr[i]);
                }
                rowIndex++;
                s = reader.ReadLine();
            }

            reader.Close();

            return matrix;
        }
    }
}
