using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Solutions
{
  /// <summary>
  /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
  /// What is the smallest number that is evenly divisible by all of the numbers from 1 to 20?
  /// </summary>
  public class Problem5 : IIntProblem
  {
    public int Solve()
    {
      int solution = 0;
      int counter = 20;

      while (solution == 0)
      {
        for (int i = 1; i <= 20; i++)
        {
          if (counter % i == 0)
          {
            if (i == 20)
            {
              solution = counter;
            }
          }
          else
          {
            counter++;
            break;
          }
        }
      }

      return solution;
    }
  }
}
