using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ProjectEuler.Interfaces;
using ProjectEuler.Shared;
using MathLibrary;

namespace ProjectEuler.Solutions
{
    public class Problem16
    {
        public BigInt Solve()
        {
            BigInt b = new BigInt(2);
            int power = 1000;

            for (int i = 1; i < power; i++)
            {
                b += b;
            }

            return b.SumDigits();
        }
    }
}
