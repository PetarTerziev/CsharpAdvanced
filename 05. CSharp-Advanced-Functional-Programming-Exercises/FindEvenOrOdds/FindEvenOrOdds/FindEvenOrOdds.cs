using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FindEvenOrOdds
{
    class FindEvenOrOdds
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string condition = Console.ReadLine();
            int startNum = nums[0];
            int endNum = nums[1];
            Func<int, bool> conditionDelegate = GetCondition(condition);
            int[] listNums = FillArray(startNum, endNum);
            Console.WriteLine(String.Join(" ", listNums.Where(conditionDelegate)));
        }

        static Func<int, bool> GetCondition(string condition)
        {
            switch (condition)
            {
                case "odd":
                    return n => n % 2 != 0;
                case "even":
                    return n => n % 2 == 0;
                default:
                    return null;
            }
        }

        static int[] FillArray(int start, int end)
        {
            List<int> list = new List<int>();

            for (int i = start; i <= end; i++)
            {
                list.Add(i);
            }

            return list.ToArray();
        }
    }
}