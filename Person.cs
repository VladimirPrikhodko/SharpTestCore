using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTestCore
{
    public interface IDefaultMethod
    {
        void ShowDefaultMethod() { 
            Console.WriteLine("In the default method of Interface"); 
        }   
    }

    internal class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
