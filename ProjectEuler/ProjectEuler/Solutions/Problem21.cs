using MathLibrary.Utilities;
using ProjectEuler.Interfaces;
using System.Linq;

namespace ProjectEuler.Solutions
{
    public class Problem21 : IIntProblem
    {
        public int Solve()
        {
            int runningTotal = 0;

            for (int i = 1; i < 10000; i++)
            {
                var sum1 = Utility.ProperFactors(i).Sum();

                if (sum1 != i)
                {
                    var sum2 = Utility.ProperFactors(sum1).Sum();
                    
                    if (sum2 == i)
                    {
                        runningTotal += i;
                    }
                }
            }

            return runningTotal;
        }
    }
}
