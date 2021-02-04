using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIteratorTask
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;
        public void Create(T[] list)
        {
            this.list = list.ToList();
        }

        public bool Move() 
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        
        }
        public bool HasNext() => index + 1 < list.Count;

        public void Print() 
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(list[index]);
            }
        }
    }
}
