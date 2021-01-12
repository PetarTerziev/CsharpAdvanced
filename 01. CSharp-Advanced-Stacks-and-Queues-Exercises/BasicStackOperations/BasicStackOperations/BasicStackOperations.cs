using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] inputInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> sequence = new Stack<int>();

            int pushCount = inputInfo[0];
            int popCount = inputInfo[1];
            int smallestElement = inputInfo[2];

            for (int i = 0; i < pushCount; i++)
            {
                sequence.Push(numbers[i]);
            }

            for (int i = 0; i < popCount; i++)
            {
                sequence.Pop();
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
