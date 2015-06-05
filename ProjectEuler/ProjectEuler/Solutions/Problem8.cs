using System;
using System.Text;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Solutions
{
  /// <summary>
  /// Find the greatest product of five consecutive digits in the 1000-digit number.
  /// </summary>
  public class Problem8 : IIntProblem
  {
    private const int NUM_FACTORS_TO_MULTIPLY = 5;

    public int Solve()
    {
      string numberString = GetNumberString();
      int largestProduct = 0;
      int startIndex = 0;
      int[] factors = new int[NUM_FACTORS_TO_MULTIPLY];

      while (startIndex < numberString.Length - NUM_FACTORS_TO_MULTIPLY)
      {
        int currentProduct = 1;

        char[] temp = numberString.Substring(startIndex, NUM_FACTORS_TO_MULTIPLY).ToCharArray();

        foreach (char c in temp)
        {
          currentProduct *= Convert.ToInt32(c.ToString());
        }

        if (currentProduct > largestProduct)
        {
          largestProduct = currentProduct;
        }

        startIndex++;
      }

      return largestProduct;
    }

    private string GetNumberString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("73167176531330624919225119674426574742355349194934");
      sb.Append("96983520312774506326239578318016984801869478851843");
      sb.Append("85861560789112949495459501737958331952853208805511");
      sb.Append("12540698747158523863050715693290963295227443043557");
      sb.Append("66896648950445244523161731856403098711121722383113");
      sb.Append("62229893423380308135336276614282806444486645238749");
      sb.Append("30358907296290491560440772390713810515859307960866");
      sb.Append("70172427121883998797908792274921901699720888093776");
      sb.Append("65727333001053367881220235421809751254540594752243");
      sb.Append("52584907711670556013604839586446706324415722155397");
      sb.Append("53697817977846174064955149290862569321978468622482");
      sb.Append("83972241375657056057490261407972968652414535100474");
      sb.Append("82166370484403199890008895243450658541227588666881");
      sb.Append("16427171479924442928230863465674813919123162824586");
      sb.Append("17866458359124566529476545682848912883142607690042");
      sb.Append("24219022671055626321111109370544217506941658960408");
      sb.Append("07198403850962455444362981230987879927244284909188");
      sb.Append("84580156166097919133875499200524063689912560717606");
      sb.Append("05886116467109405077541002256983155200055935729725");
      sb.Append("71636269561882670428252483600823257530420752963450");

      return sb.ToString();
    }
  }
}
