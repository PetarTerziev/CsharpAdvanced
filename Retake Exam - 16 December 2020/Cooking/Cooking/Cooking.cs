using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooking
{
    class Cooking
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ",
                StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ",
                StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            SortedDictionary<string, int> bakery = new SortedDictionary<string, int>();

            bakery.Add("Bread", 0);
            bakery.Add("Cake", 0);
            bakery.Add("Pastry", 0);
            bakery.Add("Fruit Pie", 0);
            

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int lastIngridinet = ingredients.Pop();
                int result = liquids.Dequeue() + lastIngridinet;

                if (!Bake(result, bakery))
                {
                    ingredients.Push(lastIngridinet + 3);
                }
            }

            StringBuilder sb = new StringBuilder();

            if (bakery.Values.All(b => b > 0))
            {
                sb.AppendLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                sb.AppendLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                sb.AppendLine("Liquids left: none");
            }
            else
            {
                sb.AppendLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                sb.AppendLine("Ingredients left: none");
            }
            else
            {
                sb.AppendLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            Console.WriteLine(sb.ToString().Trim());

            foreach (var pair in bakery)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }




        }

        public static bool Bake(int result, SortedDictionary<string, int> bakery) 
        {
            bool isCooked = false;

            switch (result)
            {
                case 25:
                    bakery["Bread"]++;
                    isCooked = true;
                    break;
                case 50:
                    bakery["Cake"]++;
                    isCooked = true;
                    break;
                case 75:
                    bakery["Pastry"]++;
                    isCooked = true;
                    break;
                case 100:
                    bakery["Fruit Pie"]++;
                    isCooked = true;
                    break;
            }

            if (isCooked)
            {
                return true;
            }

            return false;
        }
    }
}
