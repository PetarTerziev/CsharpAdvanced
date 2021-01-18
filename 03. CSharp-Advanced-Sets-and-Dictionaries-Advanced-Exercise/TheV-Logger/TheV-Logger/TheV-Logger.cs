using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> theVLogger = new Dictionary<string, Vlogger>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] tokens = null;

                if (input.Contains("joined"))
                {
                    tokens = input.Split(" joined ");
                }
                else if (input.Contains("followed"))
                {
                    tokens = input.Split(" followed ");
                }

                string followerName = tokens[0];
                string followedName = tokens[1];

                if (input.Contains("joined"))
                {
                    if (!theVLogger.ContainsKey(followerName))
                    {
                        theVLogger.Add(followerName, new Vlogger(new List<string>(), 0, 0));
                    }
                }
                else
                {
                    if (theVLogger.ContainsKey(followedName) && theVLogger.ContainsKey(followerName))
                    {
                        if (!theVLogger[followedName].FollowersNames.Any(x => x == followerName) && followedName != followerName)
                        {
                            theVLogger[followerName].Followings++;
                            theVLogger[followedName].Followers++;
                            theVLogger[followedName].FollowersNames.Add(followerName);
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {theVLogger.Count} vloggers in its logs.");
            int counter = 0;

            foreach (var pair in theVLogger.OrderByDescending(x => x.Value.Followers).ThenBy(x => x.Value.Followings))
            {
                counter++;

                Console.WriteLine($"{counter}. {pair.Key} : {pair.Value.Followers} followers, {pair.Value.Followings} following");

                if (counter == 1)
                {
                    foreach (var follower in pair.Value.FollowersNames.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }

        class Vlogger
        {
            public Vlogger(List<string> names, int followers, int followings )
            {
                this.FollowersNames = names;
                this.Followers = followers;
                this.Followings = followings;
            }
            public List<string> FollowersNames { get; set; }
            public int Followers { get; set; }
            public int Followings { get; set; }

        }
    }
}
