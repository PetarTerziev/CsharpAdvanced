using System;
using System.Collections.Generic;
using System.IO;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            Box<double> box = new Box<double>(list);

            double elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(box.GetCountOfGreatherElements(elementToCompare));
        }
    }
}
