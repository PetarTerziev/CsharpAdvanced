using System;
using System.IO;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> appendSirDelegate = n => $"Sir {n}";
            string[] names = Console.ReadLine().Split().Select(appendSirDelegate).ToArray();
            Action<string> printDelegate = p => Console.WriteLine(p);
            Array.ForEach(names, printDelegate);

        }
    }
}
