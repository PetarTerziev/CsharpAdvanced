using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestData = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> contestantInfo = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of contests")
                {
                    break;
                }

                string[] tokens = input.Split(":");
                string contestName = tokens[0];
                string paswword = tokens[1];

                if (!contestData.ContainsKey(contestName))
                {
                    contestData.Add(contestName, paswword);
                }

            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of submissions")
                {
                    break;
                }

                string[] tokens = input.Split("=>");
                string contestName = tokens[0];
                string paswword = tokens[1];


                if (contestData.ContainsKey(contestName) && contestData[contestName] == paswword)
                {

                    string contestantName = tokens[2];
                    int points = int.Parse(tokens[3]);

                    if (!contestantInfo.ContainsKey(contestantName))
                    {
                        Dictionary<string, int> newContestant = new Dictionary<string, int>();
                        contestantInfo.Add(contestantName, newContestant);
                    }

                    if (!contestantInfo[contestantName].ContainsKey(contestName))
                    {
                        contestantInfo[contestantName].Add(contestName, points);
                    }
                    else if (points > contestantInfo[contestantName][contestName])
                    {
                        contestantInfo[contestantName][contestName] = points;
                    }
                }
            }

            int maxScore = int.MinValue;
            string winner = string.Empty;

            foreach (var pair in contestantInfo)
            {
                if (pair.Value.Values.Sum() > maxScore)
                {
                    maxScore = pair.Value.Values.Sum();
                    winner = pair.Key;
                }
            }

            Console.WriteLine($"Best candidate is {winner} with total {maxScore} points.");
            Console.WriteLine("Ranking:");

            foreach (var pair in contestantInfo.OrderBy(x => x.Key))
            {
                Console.WriteLine(pair.Key);

                foreach (var contestant in pair.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestant.Key} -> {contestant.Value}");
                }
            }

        }
    }
}
