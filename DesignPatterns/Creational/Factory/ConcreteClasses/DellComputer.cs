using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Creational.Factory.AbstractClasses;

namespace DesignPatterns.Creational.Factory.ConcreteClasses
{
    public class DellComputer : Computer
    {
        int _mhz = 500;

        public override int Mhz
        {
            get { return _mhz; }
        }
    }
}
