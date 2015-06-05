using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace SimpleExamples
{
    class Program
    {
        static BlockingCollection<int> _threadResults;

        static void Main(string[] args)
        {
            //DoSimpleMapExample();

            DoSimpleReduceExample();
        }

        /// <summary>
        /// Simple Map example uses threading to demonstrate how subproblems can be computed in parallel then recombined.
        /// </summary>
        static void DoSimpleMapExample()
        {
            _threadResults = new BlockingCollection<int>();
            List<int> integers = Utility.GetIntegerList(100);
            int numSubproblems = 10;
            List<List<int>> subproblems = Utility.GetSubproblems(integers, numSubproblems);

            foreach (List<int> l in subproblems)
            {
                Thread t = new Thread(MapFunction);
                t.Start(l);
                t.Join();
            }

            foreach (int integer in integers)
            {
                Console.WriteLine(integer);
            }

            Console.WriteLine();
            Console.WriteLine("*******************************************************");
            Console.WriteLine();

            foreach (int threadResult in _threadResults)
            {
                Console.WriteLine(threadResult);
            }
        }

        static void MapFunction(object sourceList)
        {
            var computedList = ((List<int>)sourceList).Select(x => x * 2).ToList();

            foreach (int i in computedList)
            {
                _threadResults.Add(i);
            }
        }

        static void DoSimpleReduceExample()
        {
            List<int> numbers = Utility.GetIntegerList(100);

            Console.WriteLine(numbers.Aggregate((x, y) => x + y)); 

            Console.WriteLine();
        }
    }
}
