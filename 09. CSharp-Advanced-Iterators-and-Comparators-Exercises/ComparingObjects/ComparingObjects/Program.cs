using System;
using System.Collections.Generic;
using System.IO;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            int countComparedPersons = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] personInfo = input.Split();

                persons.Add(new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]));
            }

            int index = int.Parse(Console.ReadLine());
            Person comparedPerson = persons[index - 1];

            foreach (Person person in persons)
            {
                if (comparedPerson.CompareTo(person) == 0)
                {
                    countComparedPersons++;
                }
            }

            if (countComparedPersons == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countComparedPersons} {persons.Count - countComparedPersons} {persons.Count}");
            }
        }
    }
}
