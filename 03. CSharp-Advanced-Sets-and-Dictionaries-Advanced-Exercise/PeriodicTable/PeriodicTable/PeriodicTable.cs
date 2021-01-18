using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] compounds = Console.ReadLine().Split();

                foreach (var compound in compounds)
                {
                    elements.Add(compound);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
