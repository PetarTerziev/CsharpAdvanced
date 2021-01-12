using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            Queue<ushort> cupsCapacity = new Queue<ushort>(Console.ReadLine()
                                                                   .Split()
                                                                   .Select(ushort.Parse)
                                                                   .ToArray());
            Stack<ushort> bottles = new Stack<ushort>(Console.ReadLine()
                                                                   .Split()
                                                                   .Select(ushort.Parse)
                                                                   .ToArray());

            int wastedLittersOfWater = 0;
            int neededWater = 0;

            while (cupsCapacity.Count > 0 && bottles.Count > 0)
            {
                neededWater += bottles.Pop();

                if (neededWater >= cupsCapacity.Peek())
                {
                    wastedLittersOfWater += neededWater - cupsCapacity.Dequeue();
                    neededWater = 0;
                }
            }

            if (cupsCapacity.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
