using System;
using System.IO;

namespace ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string> printDelegate = s => Console.WriteLine(s);
            Array.ForEach(names, printDelegate);
        }
    }
}
