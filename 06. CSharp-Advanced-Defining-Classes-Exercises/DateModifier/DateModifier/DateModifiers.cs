using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public DateModifier(int year, int month, int day)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public static void PrintDifference(DateModifier dateOne, DateModifier dateTwo) 
        {
            DateTime firstDate = new DateTime(dateOne.Year, dateOne.Month, dateOne.Day);
            DateTime secondDate = new DateTime(dateTwo.Year, dateTwo.Month, dateTwo.Day);

            Console.WriteLine(Math.Abs((firstDate - secondDate).Days));
        }
    }
}
