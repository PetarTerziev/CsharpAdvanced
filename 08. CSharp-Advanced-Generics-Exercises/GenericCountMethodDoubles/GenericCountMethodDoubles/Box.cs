using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles

{
    public class Box<T> where T: IComparable
    {
        public Box(List<T> values)
        {
            this.Values = values;
        }
        public List<T> Values { get; set; }


        public int GetCountOfGreatherElements(T value) 
        {
            int counter = 0;

            foreach (T currentValue in this.Values)
            {
                if (value.CompareTo(currentValue) < 0)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
