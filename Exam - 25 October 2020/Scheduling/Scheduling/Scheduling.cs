using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Scheduling
{
    class Scheduling
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                
                if (tasks.Peek() == taskToBeKilled)
                {
                    tasks.Pop();
                    break;
                }
                else if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
                
            }


            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToBeKilled}");

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
