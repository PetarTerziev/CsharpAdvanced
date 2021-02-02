using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private T value ;

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return sb.Append($"{value.GetType()}: {value}").ToString();
        }
    }
}
