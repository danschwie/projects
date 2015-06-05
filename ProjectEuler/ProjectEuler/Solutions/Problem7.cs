using MathLibrary.Utilities;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Solutions
{
  /// <summary>
  /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6^(th) prime is 13.
  /// What is the 10001st prime number?
  /// </summary>
  public class Problem7 : IIntProblem
  {
    private const long LIMIT = 10001;

    public int Solve()
    {
      int numPrimes = 0;
      int current = 1;

      while (numPrimes < LIMIT)
      {
        current++;

        if (Utility.IsPrime(current))
        {
          numPrimes++;
        }
      }

      return current;
    }
  }
}
