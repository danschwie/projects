using System;
using MathLibrary.Utilities;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Solutions
{
  // The decimal number, 585 = 1001001001 (binary), is palindromic in both bases.
  // Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
  // (Please note that the palindromic number, in either base, may not include leading zeros.)
  public class Problem36 : ILongProblem
  {
    public long Solve()
    {
      long sum = 0;

      for (int i = 1; i < 1000000; i++)
      {
        if (Utility.IsPalindrome(i))
        {
          if (Utility.IsPalindrome(Convert.ToString(i, 2)))
          {
            sum += i;
          }
        }
      }

      return sum;
    }
  }
}
