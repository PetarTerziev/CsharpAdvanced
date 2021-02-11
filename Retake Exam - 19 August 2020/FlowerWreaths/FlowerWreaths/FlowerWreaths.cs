using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlowerWreaths
{
    class FlowerWreaths
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int spareFlowers = 0;
            int countWreaths = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int liliesCount = lilies.Pop();
                int flowersTaken = liliesCount + roses.Peek();

                if (flowersTaken > 15)
                {
                    lilies.Push(liliesCount - 2);
                    continue;
                }
                else if (flowersTaken < 15)
                {
                    spareFlowers += flowersTaken;
                }
                else if (flowersTaken == 15)
                {
                    countWreaths++;
                }

                roses.Dequeue();
            }

            countWreaths += spareFlowers / 15;

            if (countWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countWreaths} wreaths more!");
            }
        }
    }
}
