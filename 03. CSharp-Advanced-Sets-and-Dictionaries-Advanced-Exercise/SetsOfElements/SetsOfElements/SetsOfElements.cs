using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(); 
            int n = int.Parse(input[0].ToString());
            int m = int.Parse(input[1].ToString());
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();


            for (int i = 0; i < n + m; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i < m)
                {
                    setOne.Add(number);
                }
                else
                {
                    setTwo.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", setOne.Intersect(setTwo)));

        }
    }
}
