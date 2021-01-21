using System;
using System.IO;
using System.Linq;

namespace PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int filterLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> conditionDelegate = name => name.Length <= filterLength;

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(conditionDelegate)));
        }
    }
}
