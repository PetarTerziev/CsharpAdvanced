using System;
using System.IO;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(new string[2] {" ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "END")
                {
                    break;
                }

                string [] pushInput = tokens.Skip(1).ToArray();

                switch (command)
                {
                    case "Push":
                        stack.Push(pushInput);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }

            CustomStack<string>.PrintAll(stack);
            CustomStack<string>.PrintAll(stack);
        }
    }
}
