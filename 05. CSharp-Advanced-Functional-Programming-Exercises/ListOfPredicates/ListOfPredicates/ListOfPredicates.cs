using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class ListOfPredicates
    {
        private static object List;

        static void Main(string[] args)
        {
            int endNum = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            List<int> numbers = new List<int>();

            for (int i = 1; i <= endNum; i++)
            {
                if (divisors.All(x => i % x == 0))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

    }
}
