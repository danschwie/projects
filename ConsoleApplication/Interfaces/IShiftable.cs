using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Interfaces
{
    public interface IShiftable
    {
        int Gear { get; set; }

        void Shift(int increment);
    }
}
