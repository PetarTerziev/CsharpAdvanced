using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            int[] inputInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> sequence = new Queue<int>();

            int addCount = inputInfo[0];
            int removeCount = inputInfo[1];
            int smallestElement = inputInfo[2];

            for (int i = 0; i < addCount; i++)
            {
                sequence.Enqueue(numbers[i]);
            }

            for (int i = 0; i < removeCount; i++)
            {
                sequence.Dequeue();
            }

            if (sequence.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (sequence.Contains(smallestElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(sequence.ToArray().Min());
            }

        }
    }
}
