using System;
using System.IO;

namespace Re_Volt
{
    class ReVolt
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            int moves = int.Parse(Console.ReadLine());
            string[,] playGround = ReadMatrix(size, size);
            bool isWin = false;

            for (int i = 0; i < moves; i++)
            {
                string direction = Console.ReadLine();

                int oldRow = GetPosition(playGround, "f")[0];
                int oldCol = GetPosition(playGround, "f")[1];

                int row = GetPlayerNewPosition(oldRow, oldCol, direction, playGround)[0];
                int col = GetPlayerNewPosition(oldRow, oldCol, direction, playGround)[1];

                playGround[oldRow, oldCol] = "-";
                string sign = playGround[row, col];

                if (sign == "B")
                {
                    row = GetPlayerNewPosition(row, col, direction, playGround)[0];
                    col = GetPlayerNewPosition(row, col, direction, playGround)[1];
                    sign = playGround[row, col];

                }
                else if (sign == "T")
                {
                    row = oldRow;
                    col = oldCol;
                }

                playGround[row, col] = "f";

                if (sign == "F")
                {
                    isWin = true;
                    break;
                }
            }

            if (isWin)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(playGround);

        }

        static int[] GetPlayerNewPosition(int row, int col, string direction, string[,] matrix)
        {
            switch (direction)
            {
                case "up":
                    row = row - 1 == -1 ? matrix.GetLength(0) - 1 : row - 1;
                    break;
                case "down":
                    row = row + 1 == matrix.GetLength(0) ? 0 : row + 1;
                    break;
                case "left":
                    col = col - 1 == -1 ? matrix.GetLength(1) - 1 : col - 1; 
                    break;
                case "right":
                    col = col + 1 == matrix.GetLength(1) ? 0 : col + 1;
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
