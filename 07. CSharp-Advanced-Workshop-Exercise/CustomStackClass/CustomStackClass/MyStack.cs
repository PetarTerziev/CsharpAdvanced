using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStackClass
{
    class MyStack
    {
        public MyStack()
        {
        }
        public Node Head { get; set; }

        public int Count { get; private set; }

        public void Push(int element) 
        {
            if (Head == null)
            {
                Head = new Node(element);
            }
            else
            {
                Node newHead = new Node(element);
                newHead.Next = Head;
                Head = newHead;
            }

            Count++;
        }
        public int Pop() 
        {
            if (Head == null)
            {
                throw new InvalidOperationException("MyStack is empty");
            }

            Node oldHead = Head;
            Head = oldHead.Next;

            Count--;

            return oldHead.Value;
        }

        public int Peek()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("MyStack is empty");
            }

            return Head.Value;
        }

        public void ForEach(Action<Node> action) 
        {
            Node currentNode = Head;

            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }

        public int[] ToArray() 
        {
            List<int> result = new List<int>();

            Node currentNode = Head;

            while (currentNode != null)
            {
                result.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }

            return result.ToArray();
        }
    }
}
