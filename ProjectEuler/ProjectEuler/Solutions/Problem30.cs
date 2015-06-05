using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Interfaces;
using ProjectEuler.Shared;

namespace ProjectEuler.Solutions
{
  // Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
  // 
  //     1634 = 1^(4) + 6^(4) + 3^(4) + 4^(4)
  //     8208 = 8^(4) + 2^(4) + 0^(4) + 8^(4)
  //     9474 = 9^(4) + 4^(4) + 7^(4) + 4^(4)
  // 
  // As 1 = 1^(4) is not a sum it is not included.
  // 
  // The sum of these numbers is 1634 + 8208 + 9474 = 19316.
  // 
  // Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
  public class Problem30 : IIntProblem
  {
    // No need to try numbers higher than 1000000 because any number with 7 digits or more is larger than any
    // sum of the 5th powers of its constituent digits.
    private const int TARGET = 1000000;
    private const int POWER = 5;

    public int Solve()
    {
      int totalSum = 0;

      for (int i = 2; i < TARGET; i++)
      {
        double tempSum = 0;
        var chars = i.ToString().ToCharArray();

        for (int j = 0; j < chars.Length; j++)
        {
          double result;
          double.TryParse(chars[j].ToString(), out result);

          tempSum += Math.Pow(result, POWER);
        }

        if (tempSum == Convert.ToDouble(i))
        {
          Console.WriteLine(i);
          totalSum += i;
        }
      }

      return totalSum;
    }
  }
}
