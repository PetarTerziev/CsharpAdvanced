using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public Family()
        {
            Persons = new List<Person>();
        }
        public List<Person> Persons { get; set; }

        public void AddMember(Person member) 
        {
            Persons.Add(member);
        }

        public void GetOldestMember() 
        {
            int maxAge = 0;

            foreach (var person in Persons)
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                }
            }

            Person oldestMember = Persons.Where(p => p.Age == maxAge).FirstOrDefault();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
