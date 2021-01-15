using System;
using System.Linq;

namespace MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                             .Select(int.Parse)
                                             .ToArray();
            string[,] matrix = ReadMatrix(sizes[0], sizes[1]);

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "END")
                {
                    break;
                }

                if (command != "swap" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int rowOne = int.Parse(tokens[1]);
                int colOne = int.Parse(tokens[2]);
                int rowTwo = int.Parse(tokens[3]);
                int colTwo = int.Parse(tokens[4]);

                if (rowOne < 0 || rowOne > matrix.GetLength(1) ||
                    colOne < 0 || colOne > matrix.GetLength(0) ||
                    rowTwo < 0 || rowTwo > matrix.GetLength(1) ||
                    colTwo < 0 || colTwo > matrix.GetLength(0))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                matrix = SwapElements(matrix, rowOne, colOne, rowTwo, colTwo);
                PrintMatrix(matrix);
            }

        }


        static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        static string[,] SwapElements(string[,] matrix, int rowOne, int colOne, int rowTwo, int colTwo)
        {
            string elementOne = matrix[rowOne, colOne];
            matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
            matrix[rowTwo, colTwo] = elementOne;
            return matrix;
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
