using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStackClass
{
    class Node
    {   
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node Next { get; set; }
    }
}
