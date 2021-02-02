using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputOne = Console.ReadLine().Split();
            string[] inputTwo = Console.ReadLine().Split();
            string[] inputThree = Console.ReadLine().Split();

            string town = inputOne.Length == 5 ? $"{inputOne[3]} {inputOne[4]}" : inputOne[3];

            Tuple<string, string, string> tupleOne = new Tuple<string, string, string>
                                            ($"{inputOne[0]} {inputOne[1]}", inputOne[2], town);

            Tuple<string, int, bool> tupleTwo = new Tuple<string, int, bool>
                                            (inputTwo[0], int.Parse(inputTwo[1]), IsDrunk(inputTwo[2]));
            Tuple<string, double, string> tupleThree = new Tuple<string, double, string>
                                            (inputThree[0], double.Parse(inputThree[1]), inputThree[2]);

            Console.WriteLine(tupleOne.ToString());
            Console.WriteLine(tupleTwo.ToString());
            Console.WriteLine(tupleThree.ToString());
        }

        static bool IsDrunk(string input) 
        {
            if (input == "drunk")
            {
                return true;
            }

            return false;
        }
    }
}
