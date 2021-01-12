using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            int[] ordersInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(ordersInfo);
            int biggestOrder = orders.ToArray().Max();

            while (orders.Count > 0 && maxCapacity - orders.Peek() >= 0)
            {
                maxCapacity -= orders.Dequeue(); 
            }

            Console.WriteLine(biggestOrder);

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders.ToArray())}");
            }
        }
    }
}
