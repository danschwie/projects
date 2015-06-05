using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelDemo
{
    public class Test
    {
        static void TestMethod()
        {
            Parallel.For(0, 10, Print);
        }

        static void Print(int i)
        {
            Console.WriteLine("$$$");
        }
    }
}
