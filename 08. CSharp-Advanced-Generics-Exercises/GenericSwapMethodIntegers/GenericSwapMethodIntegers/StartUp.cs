using System;
using System.IO;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int>[] array = new Box<int>[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = new Box<int>(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(array, indexes[0], indexes[1]);
            Array.ForEach(array, x => Console.WriteLine(x.ToString()));
        }

        static void Swap<T>(T[] array, int first, int second)
        {
            T firstElement = array[first];
            array[first] = array[second];
            array[second] = firstElement;
        }
    }
}
