using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> lettersCount = new SortedDictionary<char, int>();

            foreach (var ch in text)
            {
                if (!lettersCount.ContainsKey(ch))
                {
                    lettersCount.Add(ch, 0);
                }

                lettersCount[ch]++;
            }

            foreach (var ch in lettersCount)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }

        }
    }
}
