using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Interfaces;
using ProjectEuler.Shared;

namespace ProjectEuler.Solutions
{
    public class Problem29 : IIntProblem
    {
        public int Solve()
        {
            var lowerBound = 2;
            var upperBound = 100;
            var list = new List<double>();

            for (double i = lowerBound; i <= upperBound; i++)
            {
                for (double j = lowerBound; j <= upperBound; j++)
                {
                    list.Add(Math.Pow(i, j));
                }
            }

            return list.Distinct().Count();
        }
    }
}
