using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Interfaces;
using ProjectEuler.Shared;

namespace ProjectEuler.Solutions
{
    public class Problem32 : IIntProblem
    {
        public int Solve()
        {
            //for(int = )

            return 0;
        }

        public bool IsPandigital(string s)
        {
            if (s.Length != 9)
            {
                return false;
            }

            return s.Contains("1")
                && s.Contains("2")
                && s.Contains("3")
                && s.Contains("4")
                && s.Contains("5")
                && s.Contains("6")
                && s.Contains("7")
                && s.Contains("8")
                && s.Contains("9");
        }
    }
}
