using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateCustomList
{
    public class MyCustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public MyCustomList()
        {
            items = new int[InitialCapacity];
        }
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (!IsValidIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index] = value;
            }
        }
        public void Add(int item)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = item;
            Count++;
        }

        public int RemoveAt(int index)
        {
            if (!IsValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            int item = items[index];
            items[index] = default(int);
            Shift(index);
            Count--;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return item;
        }

        public void Insert(int index, int newItem)
        {
            if (!IsValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count == items.Length)
            {
                Resize();
            }

            ShiftToRight(index);
            items[index] = newItem;
            Count++;
        }

        public int Find(int item) 
        {
            return items.FirstOrDefault(x => x == item);
        }

        public void Swap(int firstIndex, int secondIndex) 
        {

            if (!IsValidIndex(firstIndex) || !IsValidIndex(secondIndex))
            {
                throw new ArgumentOutOfRangeException();
            }

            int fisrtItem = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = fisrtItem;
        }

        public void Reverse() 
        {
            int[] copy = new int[items.Length];

            for (int i = Count - 1; i >= 0; i--)
            {
                copy[Count - 1 - i] = items[i];
            }

            items = copy;
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void Shift(int index) 
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
                items[i + 1] = default(int);
            }
        }

        private void ShiftToRight(int index)
        {

            for (int i = Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
                items[i] = default(int);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                sb.Append(items[i] + " ");
            }

            return sb.ToString().Trim() ;
        }

        private bool IsValidIndex(int index)
            => index < this.Count;

    }
}
