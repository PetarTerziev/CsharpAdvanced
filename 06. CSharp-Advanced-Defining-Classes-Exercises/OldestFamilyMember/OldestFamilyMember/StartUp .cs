using System;
using System.IO;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                Person newPerosn = new Person(personInfo[0], int.Parse(personInfo[1]));

                family.AddMember(newPerosn);
            }

            family.GetOldestMember();
        }
    }
}
