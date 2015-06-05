using MathLibrary.Utilities;
using ProjectEuler.Interfaces;

// UNFINISHED
namespace ProjectEuler.Solutions
{
  /// <summary>
  /// Find the largest prime factor of a composite number.
  /// What is the largest prime factor of the number 600851475143?
  /// </summary>
  public class Problem3 : ILongProblem
  {
    private const long TARGET = 600851475143;

    public long Solve()
    {
      return Utility.LargestPrimeFactor(TARGET);
    }
  }
}
