using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.AbstractClasses
{
    /// <summary>
    /// Invariant product interface required by the physical model.
    /// </summary>
    public abstract class Computer
    {
        public abstract int Mhz { get; }
    }
}
