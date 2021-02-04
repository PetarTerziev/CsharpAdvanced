using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = Age;
            Town = town;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
        public int CountEqualPeople { get; private set; }
        public int CompareTo(Person other)
        {
            int result = 1;

            if (other != null)
            {
                result = Name.CompareTo(other.Name);
                if ( result == 0)
                {
                    result = Age.CompareTo(other.Age);

                    if (result == 0)
                    {
                        result = Town.CompareTo(other.Town);
                    }
                }
            };

            return result;
        }
    }
}
