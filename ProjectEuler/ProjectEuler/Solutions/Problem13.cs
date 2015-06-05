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
    public class Problem13 : ILongProblem
    {
        private const string DATA_FILE = @"C:\Users\dschwie\Desktop\working\projects\ProjectEuler\ProjectEuler\Resources\Problem13\Problem13.txt";

        public Problem13()
        {
        }

        public long Solve()
        {
            string line;
            List<BigInt> bigInts = new List<BigInt>(50);

            using (StreamReader reader = new StreamReader(DATA_FILE))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    bigInts.Add(new BigInt(line));
                }
            }

            BigInt sum = 0;

            foreach (BigInt bigInt in bigInts)
            {
                sum += bigInt;
            }

            string strSum = sum.ToString();
            string first10 = strSum.Substring(0, 10);

            return Convert.ToInt64(first10);
        }
    }
}
