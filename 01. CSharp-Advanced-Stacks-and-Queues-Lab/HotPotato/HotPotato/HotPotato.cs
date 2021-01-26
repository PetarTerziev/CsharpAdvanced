using System;
using System.Collections.Generic;

namespace HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            string[] kidsList = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(kidsList);

            while (queue.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}"); 
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
