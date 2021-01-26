using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Supermarket
    {
        static void Main(string[] args)
        {
            Queue<string> marketQueue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input != "Paid")
                {
                    marketQueue.Enqueue(input);
                }
                else
                {
                    while (marketQueue.Count > 0)
                    {
                        Console.WriteLine(marketQueue.Dequeue());
                    }
                }
            }

            Console.WriteLine($"{marketQueue.Count} people remaining.");
        }
    }
}
