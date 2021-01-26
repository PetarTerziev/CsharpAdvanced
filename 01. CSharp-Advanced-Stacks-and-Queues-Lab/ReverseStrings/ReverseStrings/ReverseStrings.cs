using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();
            Stack<char> result = new Stack<char>(words);

            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }

        }
    }
}
