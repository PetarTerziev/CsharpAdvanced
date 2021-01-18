using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] clothesInfo = Console.ReadLine().Split(" -> ").ToArray();
                string color = clothesInfo[0];
                string[] clothesList = clothesInfo[1].Split(",").ToArray();

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var dress in clothesList)
                {
                    if (!clothes[color].ContainsKey(dress))
                    {
                        clothes[color].Add(dress, 0);
                    }

                    clothes[color][dress]++;
                }
            }

            string[] searchDress = Console.ReadLine().Split();

            foreach (var pair in clothes)
            {
                Console.WriteLine($"{pair.Key} clothes:");

                foreach (var dress in pair.Value)
                {
                    string message = pair.Key == searchDress[0] && dress.Key == searchDress[1] ? " (found!)" : "";

                    Console.WriteLine($"* {dress.Key} - {dress.Value}{message}");
                }
            }
        }
    }
}
