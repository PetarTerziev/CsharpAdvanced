using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class LootBox
    {
        static void Main(string[] args)
        {
            Queue<int> lootBoxOne = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> lootBoxTwo = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int sumOfItems = 0;

            while (lootBoxOne.Count > 0 && lootBoxTwo.Count >0)
            {
                int lastItem = lootBoxTwo.Pop();
                int sum = lootBoxOne.Peek() + lastItem;

                if (sum % 2 == 0)
                {
                    sumOfItems += sum;
                    lootBoxOne.Dequeue();
                }
                else
                {
                    lootBoxOne.Enqueue(lastItem);
                }
            }

            if (lootBoxOne.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (lootBoxTwo.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumOfItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfItems}");
            }
        }
    }
}
