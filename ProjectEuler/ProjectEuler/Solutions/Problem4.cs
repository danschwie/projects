using System.Collections.Generic;
using System.Linq;
using MathLibrary.Utilities;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Solutions
{
  public class Problem4 : IIntProblem
  {
    public int Solve()
    {
      List<int> palindromes = new List<int>();

      for (int i = 999; i > 99; i--)
      {
        for (int j = 999; j > 99; j--)
        {
          if (Utility.IsPalindrome((i * j).ToString()))
          {
            palindromes.Add(i * j);
          }
        }
      }

      return 
        (from p in palindromes
         select p).Max();
    }
  }
}
