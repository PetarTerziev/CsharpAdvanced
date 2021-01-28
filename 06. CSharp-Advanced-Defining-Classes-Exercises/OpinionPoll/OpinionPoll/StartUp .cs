using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                Person newPerson = new Person(Console.ReadLine().Split());
                persons.Add(newPerson);
            }

            Array.ForEach(persons.Where(p => p.Age > 30).OrderBy(p => p.Name).ToArray(), 
                                        p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
