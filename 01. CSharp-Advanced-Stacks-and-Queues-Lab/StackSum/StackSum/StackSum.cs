using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(input);

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0].ToLower();

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        for (int i = 1; i <= 2; i++)
                        {
                            numbers.Push(int.Parse(tokens[i]));
                        }
                        break;
                    case "remove":
                        int number = int.Parse(tokens[1]);

                        if (number <= numbers.Count)
                        {
                            for (int i = 0; i < number; i++)
                            {
                                numbers.Pop();
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
