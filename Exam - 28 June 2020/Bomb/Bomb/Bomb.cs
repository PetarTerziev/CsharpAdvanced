using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bomb
{
    class Bomb
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            SortedDictionary<string, int> bombPouch = new SortedDictionary<string, int>();
            bombPouch.Add("Datura Bombs", 0);
            bombPouch.Add("Cherry Bombs", 0);
            bombPouch.Add("Smoke Decoy Bombs", 0);

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                if (bombPouch.Values.All(b => b >= 3))
                {
                    break;
                }

                int bombCasingValue = bombCasings.Pop();
                int bombValue = bombEffects.Peek() + bombCasingValue;

                if (bombValue == 40)
                {
                    bombPouch["Datura Bombs"]++;
                }
                else if (bombValue == 60)
                {
                    bombPouch["Cherry Bombs"]++;
                }
                else if (bombValue == 120)
                {
                    bombPouch["Smoke Decoy Bombs"]++;
                }
                else
                {
                    bombCasings.Push(bombCasingValue - 5);
                    continue;
                }

                bombEffects.Dequeue();
            }

            if (bombPouch.Values.All(b => b >= 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }

            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }

            foreach (var bomb in bombPouch)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
