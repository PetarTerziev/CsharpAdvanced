using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();
            Stack<string> numbers = new Stack<string>(input);

            while (numbers.Count > 1)
            {
                int firstNumber = int.Parse(numbers.Pop());
                string sign = numbers.Pop();
                int secondNumber = int.Parse(numbers.Pop());

                switch (sign)
                {
                    case "+":
                        numbers.Push((firstNumber + secondNumber).ToString());
                        break;
                    case "-":
                        numbers.Push((firstNumber - secondNumber).ToString());
                        break;
                }
            }

            Console.WriteLine(numbers.Pop());
        }
    }
}
