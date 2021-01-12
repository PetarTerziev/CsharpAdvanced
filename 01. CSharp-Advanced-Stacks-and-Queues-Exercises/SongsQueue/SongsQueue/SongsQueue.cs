using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class SongsQueue
    {
        static void Main(string[] args)
        {
            string[] songsList = Console.ReadLine().Split(", ");
            Queue<string> songsQueue = new Queue<string>(songsList);

            while (true)
            {
                if (songsQueue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                string command = Console.ReadLine();
                string song = string.Empty;

                if (command.Contains("Add"))
                {
                    song = command.Replace("Add ", "");
                    command = "Add";
                }

                switch (command)
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;
                    case "Add":
                        if (!songsQueue.Contains(song))
                        {
                            songsQueue.Enqueue(song);
                        }
                        else
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songsQueue.ToArray()));
                        break;
                }
            }
        }
    }
}
