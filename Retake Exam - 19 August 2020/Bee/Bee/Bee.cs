using System;
using System.IO;

namespace Bee
{
    class Bee
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] garden = ReadMatrix(size, size);
            bool isOutOfGarden = false;
            int polinationedCount = 0;
            string direction = Console.ReadLine();

            while (direction != "End")
            {
                int oldRow = GetPosition(garden, "B")[0];
                int oldCol = GetPosition(garden, "B")[1];

                int row = GetPlayerNewPosition(oldRow, oldCol, direction)[0];
                int col = GetPlayerNewPosition(oldRow, oldCol, direction)[1];

                garden[oldRow, oldCol] = ".";

                if (row < 0 || row >= garden.GetLength(0) ||
                    col < 0 || col >= garden.GetLength(1))
                {
                    isOutOfGarden = true;
                    break;
                }
                else 
                {
                    string sign = garden[row, col];

                    if (sign == "O")
                    {
                        garden[row, col] = ".";

                        row = GetPlayerNewPosition(row, col, direction)[0];
                        col = GetPlayerNewPosition(row, col, direction)[1];
                    }

                    sign = garden[row, col];

                    if (sign == "f")
                    {
                        polinationedCount++;
                    }

                    garden[row, col] = "B";
                }

                direction = Console.ReadLine();
                
            }

            if (isOutOfGarden)
            {
                Console.WriteLine("The bee got lost!");
            }

            if(polinationedCount < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinationedCount} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinationedCount} flowers!");
            }

            PrintMatrix(garden);

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
