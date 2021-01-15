using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMOves
{
    class SnakeMOves
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            char[,] matrix = ReadMatrix(sizes[0], sizes[1], snake);

            PrintMatrix(matrix);
        }


        static char[,] ReadMatrix(int rows, int cols, string data)
        {
            char[,] matrix = new char[rows, cols];
            Queue<char> snake = new Queue<char>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (snake.Count == 0)
                    {
                        snake = new Queue<char>(data);
                    }

                    if (row % 2 != 0)
                    {
                        matrix[row, matrix.GetLength(1) - 1 - col] = snake.Dequeue();
                    }
                    else
                    {
                        matrix[row, col] = snake.Dequeue();
                    }
                    
                }
            }

            return matrix;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

        }
    }
}
