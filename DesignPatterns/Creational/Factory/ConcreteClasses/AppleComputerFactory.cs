using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Creational.Factory.AbstractClasses;

namespace DesignPatterns.Creational.Factory.ConcreteClasses
{
    public class AppleComputerFactory : ComputerFactory
    {
        public override Computer GetComputer()
        {
            return new AppleComputer();
        }
    }
}
