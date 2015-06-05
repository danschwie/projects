using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgrammingCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static List<string> Process(List<string> data, Func<string, string> func)
        {
            List<string> transformed = new List<string>(data.Count);
            //transformed = data.Select(s => Func(s));

            foreach (string s in data)
            {
                transformed.Add(func(s));
            }

            return transformed;
        }

        static List<string> GetData()
        {
            return new List<string>()
            {
                "Bob",
                "Amy",
                "Joe",
                "Zoey"
            };
        }

        static void Print(List<string> data)
        {
            data.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
        }
    }
}
