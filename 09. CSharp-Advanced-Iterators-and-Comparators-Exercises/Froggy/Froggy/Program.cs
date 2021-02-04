using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake(Console.ReadLine().Split(", ").Select(int.Parse).ToList());
            List<int> result = new List<int>();

            foreach (var stone in lake)
            {
                result.Add(stone);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
