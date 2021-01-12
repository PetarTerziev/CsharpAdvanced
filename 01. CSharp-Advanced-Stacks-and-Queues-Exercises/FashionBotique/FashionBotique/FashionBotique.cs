using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBotique
{
    class FashionBotique
    {
        static void Main(string[] args)
        {
            int[] boxOfClothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(boxOfClothes);
            int rackCount = 0;
            int storedClothesCount = 0;

            while (clothes.Count > 0)
            {
                if (storedClothesCount + clothes.Peek() <= rackCapacity)
                {
                    storedClothesCount += clothes.Pop();

                    if (clothes.Count == 0)
                    {
                        rackCount++;
                    }
                }
                else
                {
                    rackCount++;
                    storedClothesCount = 0;
                }
            }

            Console.WriteLine(rackCount);
        }
    }
}
