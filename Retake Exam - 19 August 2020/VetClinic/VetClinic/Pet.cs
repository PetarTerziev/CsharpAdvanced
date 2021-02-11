using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Pet
    {
        private string name;
        private int age;
        private string owner;
        public Pet(string name, int age, string owner)
        {
            this.name = name;
            this.age = age;
            this.owner = owner;
        }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Owner { get => owner; set => owner = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name} Age: {Age} Owner: {Owner}");
            return sb.ToString().Trim();
        }
    }
}
