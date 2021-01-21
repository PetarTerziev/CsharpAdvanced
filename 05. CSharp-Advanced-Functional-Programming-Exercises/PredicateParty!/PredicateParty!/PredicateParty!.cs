using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                if (command == "Party!")
                {
                    break;
                }

                Func<string, bool> conditionDelegate = ApplyFilterCriteria(input[1], input[2]);

                List<string> tempList = guests.ToList();

                foreach (var guest in guests)
                {
                    if (conditionDelegate(guest))
                    {
                        if (command == "Remove")
                        {
                            tempList.Remove(guest);
                        }
                        else
                        {
                            int index = tempList.IndexOf(guest);
                            tempList.Insert(Math.Min(index + 1, tempList.Count - 1), guest);
                        }
                    }
                }

                guests = tempList.ToList();
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.Write(String.Join(", ", guests ));
                Console.Write(" are going to the party!");
            }
        }

        static Func<string, bool> ApplyFilterCriteria(string criteria, string condition) 
        {

            switch (criteria)
            {
                case "StartsWith":
                    return g => g.Substring(0, condition.Length) == condition;
                case "EndsWith":
                    return g => g.Substring(g.Length - condition.Length, condition.Length) == condition;
                case "Length":
                    return g => g.Length == int.Parse(condition);
                default:
                    return null;
            }
        }
    }
}
