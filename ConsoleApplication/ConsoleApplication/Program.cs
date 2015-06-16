using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "23423,54543,56454";

            List<string> l = s.Split(',').ToList();
        }
    }
}
