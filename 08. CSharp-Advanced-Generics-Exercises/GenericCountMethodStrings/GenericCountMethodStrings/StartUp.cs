using System;
using System.Collections.Generic;
using System.IO;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            Box<string> box = new Box<string>(list);

            string elementToCompare = Console.ReadLine();

            Console.WriteLine(box.GetCountOfGreatherElements(elementToCompare));

        }
    }
}
