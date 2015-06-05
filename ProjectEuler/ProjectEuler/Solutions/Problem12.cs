using System;
using MathLibrary.Utilities;
using ProjectEuler.Interfaces;

namespace ProjectEuler.Solutions
{
    public class Problem12 : ILongProblem
    {
        public long Solve()
        {
            for (int i = 2; i < 200; i++)
            {
                long triangleNumber = Utility.TriangleNumber(i);
                int numFactors = Utility.NumFactors(triangleNumber);

                Console.WriteLine("Index {0} : {1} has {2} factors", i, triangleNumber, numFactors);
            }

            //Console.WriteLine(Utility.NumFactors(10000000));

            //int floor = 0;
            //int ceiling = 1000;
            //int range = 1000;
            //int maxCeiling = 20000;

            //while (ceiling <= maxCeiling)
            //{
            //    Console.WriteLine("Max # of factors between {0} and {1} : {2}", floor, ceiling, Utility.MaxNumberOfFactors(floor, ceiling));
            //    floor = ceiling;
            //    ceiling += range;
            //}

            return 1;
        }
    }
}
