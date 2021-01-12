using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> parentheses = new Stack<char>();

            foreach (char ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    parentheses.Push(ch);
                }
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    if (parentheses.Count == 0)
                    {
                        parentheses.Push(ch);
                    }
                    else if (parentheses.Peek() == '(' && ch == ')')
                    {
                        parentheses.Pop();
                    }
                    else if (parentheses.Peek() == '{' && ch == '}')
                    {
                        parentheses.Pop();
                    }
                    else if (parentheses.Peek() == '[' && ch == ']')
                    {
                        parentheses.Pop();
                    }
                }
            }

            if (parentheses.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
