using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    class PartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            string [] guests = Console.ReadLine().Split();
            List<string> filteredKeys = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Contains("Print"))
                {
                    break;
                }

                filteredKeys.Add(input);
            }

            filteredKeys = RemoveFilters(filteredKeys);

            foreach (var item in filteredKeys)
            {
                string[] tokens = item.Split(";");
                Func<string, bool> conditionDelegate = ApplyFilterCriteria(tokens[1], tokens[2]);
                guests = guests.Where(conditionDelegate).ToArray();
                
            }

            Console.WriteLine(String.Join(" ", guests));
        }

        static Func<string, bool> ApplyFilterCriteria(string criteria, string condition)
        {
            switch (criteria)
            {
                case "Starts with":
                    return g => g.Substring(0, condition.Length) != condition;
                case "Ends with":
                    return g => g.Substring(g.Length - condition.Length, condition.Length) != condition;
                case "Length":
                    return g => g.Length != int.Parse(condition);
                case "Contains":
                    return g => !g.Contains(condition);
                default:
                    return null;
            }
        }

        static List<string> RemoveFilters(List<string> filters) 
        {
            List<string> temp = filters.ToList();

            for (int i = filters.Count - 1; i >= 0; i--)
            {
                if (filters[i].Contains("Remove"))
                {
                    string removeFilter = filters[i].Replace("Remove", "Add");
                    temp.Remove(removeFilter);
                    temp.Remove(filters[i]);
                }
            }

            return temp;
        }
    }
}
