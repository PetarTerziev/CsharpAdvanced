using System;
using System.Linq;

namespace CreateCustomList
{
    class CreateCustomList
    {
        static void Main(string[] args)
        {
            MyCustomList list = new MyCustomList();

            list.Add(5);
            list.Add(6);
            list.Add(105);
            list.Add(8);

            list.RemoveAt(0);

            list.Insert(1, 100000);
            list.Insert(1, 120);
            list.Insert(1, 500);

            list.Swap(0, 5);

            Console.WriteLine(list.ToString());


            list.Reverse();

            Console.WriteLine(list.ToString());

            Console.WriteLine(list.Find(120000));

        }
    }
}
