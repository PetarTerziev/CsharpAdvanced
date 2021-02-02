using System;
using System.Collections.Generic;
using System.IO;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputOne = Console.ReadLine().Split();
            string[] inputTwo = Console.ReadLine().Split();
            string[] inputThree = Console.ReadLine().Split();

            Tuple<string, string> tupleOne = new Tuple<string, string>
                                            ($"{inputOne[0]} {inputOne[1]}", inputOne[2]);
            Tuple<string, int> tupleTwo = new Tuple<string, int>
                                            (inputTwo[0], int.Parse(inputTwo[1]));
            Tuple<int, double> tupleThree = new Tuple<int, double>
                                            (int.Parse(inputThree[0]), double.Parse(inputThree[1]));

            Console.WriteLine(tupleOne.ToString());
            Console.WriteLine(tupleTwo.ToString());
            Console.WriteLine(tupleThree.ToString());
        }
    }
}
