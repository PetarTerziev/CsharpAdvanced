using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            Console.WriteLine($"{person.Name}-{person.Age}");

            Person person2 = new Person(25);

            Console.WriteLine($"{person2.Name}-{person2.Age}");

            Person person3 = new Person("pesho", 32);

            Console.WriteLine($"{person3.Name}-{person3.Age}");
        }
    }
}
