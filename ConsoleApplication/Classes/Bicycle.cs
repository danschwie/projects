using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.BaseClasses;
using ConsoleApplication.Interfaces;

namespace ConsoleApplication.Classes
{
    public class Bicycle : Vehicle, IShiftable
    {
        public int Gear { get; set; }

        public Bicycle()
        {
            Make = "";
            Model = "";
            ManufactoredOn = DateTime.Now;
            Gear = 1;
        }

        public void Shift(int increment)
        {
            int newGear = Gear + increment;

            if (newGear >= 1 && newGear <= 21)
            {
                Gear += increment;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Make: {0}{1}", Make, Environment.NewLine));
            sb.Append(string.Format("Model: {0}{1}", Model, Environment.NewLine));
            sb.Append(string.Format("ManufactoredOn: {0}{1}", ManufactoredOn, Environment.NewLine));
            sb.Append(string.Format("Gear: {0}{1}", Gear, Environment.NewLine));

            return sb.ToString();
        }
    }
}
