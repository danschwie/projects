using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.BaseClasses
{
    public abstract class Vehicle
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public DateTime ManufactoredOn { get; set; }
    }
}
