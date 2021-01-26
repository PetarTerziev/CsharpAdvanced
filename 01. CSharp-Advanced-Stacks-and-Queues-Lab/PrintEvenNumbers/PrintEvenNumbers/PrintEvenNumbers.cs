using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class PrintEvenNumbers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Queue<string> numbers = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (int.Parse(input[i]) % 2 == 0)
                {
                    numbers.Enqueue(input[i]);
                }
            }

            while (numbers.Count > 0)
            {
                if (numbers.Count == 1)
                {
                    Console.Write(numbers.Dequeue());
                }
                else
                {
                    Console.Write(numbers.Dequeue() + ", ");
                }
                
            }
        }
    }
}
