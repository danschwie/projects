using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Interfaces;
using MathLibrary.Utilities;
using MathLibrary;

namespace ProjectEuler.Solutions
{
    public class Problem25 : IIntProblem
    {
        public int Solve()
        {
            var interval = 100;
            var term = interval;

            while (true)
            {
                var value = SequenceGenerator.GetFibonacciTermValue(term);

                Console.WriteLine(value.Length);
                
                if(value.Length >= 1000)
                {
                    term -= interval;

                    for (int i = term; i <= term + 10; term++ )
                    {
                        value = SequenceGenerator.GetFibonacciTermValue(term);

                        if (value.Length >= 1000)
                        {
                            return term;
                        }
                    }
                }

                term += interval;
            }

            return 0;
        }
    }
}
