using System;
using System.IO;
using System.Linq;

namespace AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(String.Join(" ", numbers));
                }
                else
                {
                    numbers = numbers.Select(ApplyCommand(numbers, command)).ToArray();
                }

                command = Console.ReadLine();
            }

        }

        static Func<int, int> ApplyCommand(int[] array, string command) 
        {
            switch (command)
            {
                case "add":
                    return n => n + 1;
                case "subtract":
                    return n => n - 1;
                case "multiply":
                    return n => n * 2;
                default:
                    return null;
            }
        }
    }
}
