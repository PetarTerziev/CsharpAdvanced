using System;
using System.IO;
using System.Linq;

namespace CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, bool> minDelegate = num => num == nums.Min();

            Console.WriteLine(nums.Where(minDelegate).FirstOrDefault());
        }
    }
}
