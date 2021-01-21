using System;
using System.IO;
using System.Linq;

namespace ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .Reverse()
                   .ToArray();
            int num = int.Parse(Console.ReadLine());

            Func<int, bool> conditionDelegate = n => n % num != 0;
            numbers = numbers.Where(conditionDelegate).ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
