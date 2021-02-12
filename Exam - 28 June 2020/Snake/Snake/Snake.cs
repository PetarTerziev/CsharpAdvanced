using System;
using System.IO;
using System.Linq;

namespace Snake
{
    class Snake
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] burrow = ReadMatrix(size, size);
            int eatenFood = 0;
            bool isOutOfBurrow = false;

            while (eatenFood < 10)
            {
                string direction = Console.ReadLine();

                int oldRow = GetPosition(burrow, "S")[0];
                int oldCol = GetPosition(burrow, "S")[1];

                int row = GetPlayerNewPosition(oldRow, oldCol, direction)[0];
                int col = GetPlayerNewPosition(oldRow, oldCol, direction)[1];

                burrow[oldRow, oldCol] = ".";

                if (row < 0 || row >= burrow.GetLength(0) ||
                    col < 0 || col >= burrow.GetLength(1))
                {
                    isOutOfBurrow = true;
                    break;
                }
                else
                {
                    string sign = burrow[row, col];

                    if (sign == "B")
                    {
                        burrow[row, col] = ".";
                        row = GetPosition(burrow, "B")[0];
                        col = GetPosition(burrow, "B")[1];
                    }
                    else if (sign == "*")
                    {
                        eatenFood++;
                    }

                    burrow[row, col] = "S";
                }
            }

            if (isOutOfBurrow)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {eatenFood}");

            PrintMatrix(burrow);


        }

        static int[] GetPlayerNewPosition(int row, int col, string direction)
        {
            switch (direction)
            {
                case "up":
                    row -= 1;
                    break;
                case "down":
                    row += 1;
                    break;
                case "left":
                    col -= 1;
                    break;
                case "right":
                    col += 1;
                    break;

            }

            return new int[2] { row, col };
        }

        static int[] GetPosition(string[,] matrix, string sign)
        {
            int[] result = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == sign)
                    {
                        result[0] = row;
                        result[1] = col;
                    }
                }
            }

            return result;
        }

        static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col].ToString();
                }
            }

            return matrix;
        }

        static void PrintMatrix(string[,] matrix)
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
