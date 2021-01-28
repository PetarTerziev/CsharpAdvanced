using System;
using System.IO;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] dateOne = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] dateTwo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            DateModifier firstDate = CreateDate(dateOne);
            DateModifier secondDate = CreateDate(dateTwo);

            DateModifier.PrintDifference(firstDate, secondDate);
        }

        static DateModifier CreateDate(int [] date) 
        {
            return new DateModifier(date[0], date[1], date[2]);
        }
    }
}
