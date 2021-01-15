using System;
using System.Linq;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[][] matrix = ReadMatrix(new int[sizes[0]][]);
            int maxSum = int.MinValue;
            int[] startPos = new int[2];

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int sum = 0;
                    sum += matrix[row].ToList().Skip(col).Take(3).Sum();
                    sum += matrix[row + 1].ToList().Skip(col).Take(3).Sum();
                    sum += matrix[row + 2].ToList().Skip(col).Take(3).Sum();

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startPos[0] = row;
                        startPos[1] = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            PrintMatrix(matrix, startPos);

        }

        static int[][] ReadMatrix(int [][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = new int[rowData.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = rowData[col];
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[][] matrix, int[] startPos)
        {
            for (int row = startPos[0]; row < startPos[0] + 3; row++)
            {
                for (int col = startPos[1]; col < startPos[1] + 3; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
