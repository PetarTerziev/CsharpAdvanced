using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Head { get; set; }
            public Node Next { get; set; }
        }

        private Node head;
        public int Count { get; set; }

        public void Push(T[] array) 
        {
            foreach (T element in array)
            {
                Node newNode = new Node(element);

                if (Count == 0)
                {
                    head = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head = newNode;
                }
                Count++;
            } 
        }

        public static void PrintAll(CustomStack<T> array) 
        {
            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
        }
        public T Pop() 
        { 
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            Node currenthead = head;
            head = head.Next;
            Count--;

            return currenthead.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node tempHead = head;

            while (tempHead != null)
            {
                Node currentNode = tempHead;
                tempHead = tempHead.Next;
                yield return currentNode.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
