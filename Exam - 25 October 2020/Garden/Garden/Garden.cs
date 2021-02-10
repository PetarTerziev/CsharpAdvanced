using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Garden
{
    class Garden
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] garden = FillMatrix(dimensions[0], dimensions[1]);
            List<Tuple<int, int>> seedsCcordinates = new List<Tuple<int, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Bloom Bloom Plow")
                {
                    break;
                }

                int[] splited = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int row = splited[0];
                int col = splited[1];

                if (row < 0 || row >= garden.Length || col < 0 || col >= garden[0].Length)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    seedsCcordinates.Add(new Tuple<int, int> (row, col));
                }
            }

            Bloom(garden, seedsCcordinates);
            PrintMatrix(garden);
        }

        private static void Bloom(int[][] jagged, List<Tuple<int, int>> seedsCcordinates)
        {
            foreach (var seed in seedsCcordinates)
            {
                int row = seed.Item1;
                int col = seed.Item2;

                jagged[row] = jagged[row].Select(f => f+= 1).ToArray();

                for (int i = 0; i < jagged.Length; i++)
                {
                    if (i != row)
                    {
                        jagged[i][col] += 1;
                    }
                }
            }
        }

        static int[][] FillMatrix(int rows, int cols)
        {
            int[][] jagged = new int[rows][];

            for (int row = 0; row < jagged.Length; row++)
            {
                jagged[row] = new int[cols];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = 0;
                }
            }

            return jagged;
        }
        static void PrintMatrix(int[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
