using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication.Classes
{
    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int NumOrders { get; set; }

        public bool? Archived{ get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} : {2}", FirstName, LastName, Age);
        }

        public int CompareTo(Person obj)
        {
            int x = this.LastName.CompareTo(obj.LastName);
            return x;
        }
    }
}
