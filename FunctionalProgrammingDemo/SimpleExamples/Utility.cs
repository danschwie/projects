using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleExamples
{
    public class Utility
    {
        public static List<int> GetIntegerList(int size)
        {
            List<int> integers = new List<int>(size);

            for (int i = 1; i <= size; i++)
            {
                integers.Add(i);
            }

            return integers;
        }

        public static List<List<int>> GetSubproblems(List<int> masterList, int numSubproblems)
        {

            List<List<int>> subproblems = new List<List<int>>(numSubproblems);

            for (int i = 0; i < masterList.Count / numSubproblems; i++)
            {   
                subproblems.Add(new List<int>(masterList.Skip(i * 10).Take(masterList.Count / numSubproblems)));
            }

            return subproblems;
        }
    }
}
