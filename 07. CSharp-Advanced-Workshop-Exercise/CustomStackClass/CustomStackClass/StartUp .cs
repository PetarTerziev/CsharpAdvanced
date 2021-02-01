using System;
using System.Collections;

namespace CustomStackClass
{
    class StartUp
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();

            Console.WriteLine(stack.Count);
            stack.Push(1);
            stack.Push(55);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Count);

            stack.Push(150);
            stack.Push(1000);

            stack.ForEach(x => Console.WriteLine(x.Value));
            Console.WriteLine(stack.Count);
            Console.WriteLine(string.Join(" ",stack.ToArray()));
        }
    }
}
