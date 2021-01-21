using System;
using System.Linq;

namespace CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .Reverse()
                   .ToArray();

            Console.WriteLine(string.Join(" ", numbers
                              .Where(x => x % 2 == 0)
                              .OrderBy(x => x)
                              .Concat(numbers.Where(x => x % 2 != 0).OrderBy(x => x))));
        }
    }
}
