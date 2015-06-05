using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Creational.Factory.AbstractClasses;

namespace DesignPatterns.Creational.Factory
{
    public static class ComputerAssembler
    {
        public static void AssembleComputer(ComputerFactory factory)
        {
            Computer computer = factory.GetComputer();

            Console.WriteLine("assembled a {0} running at {1} MHz", computer.GetType().FullName, computer.Mhz);
        }
    }
}
