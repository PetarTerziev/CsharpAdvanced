using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class MaximumAndMinimumElement
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (byte i = 0; i < n; i++)
            {
                int[] operations = Console.ReadLine().Split().Select(int.Parse).ToArray();
                bool isStackEmpty = numbers.Count == 0;

                switch (operations[0])
                {
                    case 1:
                        numbers.Push(operations[1]);
                        break;
                    case 2:
                        if (!isStackEmpty)
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (!isStackEmpty)
                        {
                            Console.WriteLine(numbers.ToArray().Max());
                        }
                        break;
                    case 4:
                        if (!isStackEmpty)
                        {
                            Console.WriteLine(numbers.ToArray().Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers.ToArray()));
        }
    }
}
