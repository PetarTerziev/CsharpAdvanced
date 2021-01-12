using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Stack<string> changes = new Stack<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                switch (command)
                {
                    case "1":
                        changes.Push(text);
                        text = String.Concat(text, tokens[1]);
                        break;
                    case "2":
                        changes.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(tokens[1]));
                        break;
                    case "3":
                        Console.WriteLine(text.Substring(int.Parse(tokens[1]) - 1, 1));
                        break;
                    case "4":
                        if (changes.Count > 0)
                        {
                            text = changes.Pop();
                        }
                        break;
                }
            }

        }
    }
}
