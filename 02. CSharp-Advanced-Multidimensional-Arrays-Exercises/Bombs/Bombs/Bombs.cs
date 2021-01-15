using System;
using System.Linq;

namespace Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(rows, rows);
            string[] bombCoordinates = Console.ReadLine().Split();

            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                int[] firstBomb = bombCoordinates[i].Split(",").Select(int.Parse).ToArray();
                int row = firstBomb[0];
                int col = firstBomb[1];

                matrix = DetonateBomb(matrix, row, col);
            }

            Console.WriteLine($"Alive cells: {SumAndCounMatrix(matrix)[1]}");
            Console.WriteLine($"Sum: {SumAndCounMatrix(matrix)[0]}");
            PrintMatrix(matrix);

        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        static int[,] DetonateBomb(int[,] matrix, int rowBomb, int colBomb) 
        {
            int startRow = Math.Max(rowBomb - 1, 0);
            int startCol = Math.Max(colBomb - 1, 0);
            int endRow = Math.Min(rowBomb + 1, matrix.GetLength(0) - 1);
            int endCol = Math.Min(colBomb + 1, matrix.GetLength(1) - 1);
            int bombValue = matrix[rowBomb, colBomb];

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (matrix[row, col] > 0 && bombValue > 0)
                    {
                        matrix[row, col] -= bombValue;
                    }
                }
            }
            return matrix;   
        }

        static int[] SumAndCounMatrix(int[,] matrix) 
        {
            int[] result = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        result[0] += matrix[row, col];
                        result[1]++;
                    }
                }
            }

            return result;
        }

        static void PrintMatrix(int[,] matrix)
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
