using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Employee
    {
        private string name;

        private int age;

        private string country;

        public Employee(string name, int age, string country)
        {
            this.name = name;
            this.age = age;
            this.Country = country;
        }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Country { get => country; set => country = value; }

        public override string ToString()
        {
            return $"Employee: {Name}, {Age} ({Country})";
        }
    }
}
