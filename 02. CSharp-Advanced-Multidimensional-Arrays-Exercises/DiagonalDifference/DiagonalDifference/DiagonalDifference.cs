using System;
using System.Linq;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int sizeSquareMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(sizeSquareMatrix, sizeSquareMatrix);
            Console.WriteLine(Math.Abs(SumPrimaryDiagonal(matrix) - SumSecondaryDiagonal(matrix)));

        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }
        static int SumPrimaryDiagonal(int[,] matrix)
        {
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, row];
            }

            return sum;
        }

        static int SumSecondaryDiagonal(int[,] matrix)
        {
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, matrix.GetLength(1) - row - 1];
            }

            return sum;
        }
    }
}
