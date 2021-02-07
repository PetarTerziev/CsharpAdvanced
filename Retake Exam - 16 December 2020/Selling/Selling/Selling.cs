using System;
using System.IO;
using System.Linq;

namespace Selling
{
    class Selling
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] store = ReadMatrix(size, size);
            int[] startPos = GetStartPosition(store);
            bool isPlayerOut = false;
            int money = 0;

            while (money < 50 && !isPlayerOut)
            {
                string direction = Console.ReadLine();
                int oldRow = GetStartPosition(store)[0];
                int oldCol = GetStartPosition(store)[1];

                int[] newCoordinates = MovePlayer(store, direction);
                int row = newCoordinates[0];
                int col = newCoordinates[1];

                if (row < 0 || row >= store.GetLength(0) || 
                    col < 0 || col >= store.GetLength(1))
                {
                    isPlayerOut = true;
                    store[oldRow, oldCol] = "-";
                }
                else
                {
                    string sign = store[row, col];

                    if (sign == "O")
                    {
                        store[oldRow, oldCol] = "-";
                        store[row, col] = "-";
                        int[] newCoordinatesPilar = GetPositionOfPilar(store);

                        store[newCoordinatesPilar[0], newCoordinatesPilar[1]] = "S";
                    }
                    else if (sign != "-")
                    {
                        money += int.Parse(sign);
                        store[oldRow, oldCol] = "-";
                        store[row, col] = "S";
                    }
                    else
                    {
                        store[oldRow, oldCol] = "-";
                        store[row, col] = "S";
                    }
                }
            }

            if (isPlayerOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");

            PrintMatrix(store);
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

        static int[] MovePlayer(string [,] matrix , string direction)
        {
            int row = GetStartPosition(matrix)[0];
            int col = GetStartPosition(matrix)[1];

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

        static int[] GetStartPosition(string[,] matrix)
        {
            int[] result = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "S")
                    {
                        result[0] = row;
                        result[1] = col;
                    }
                }
            }

            return result;
        }

        static int[] GetPositionOfPilar(string[,] matrix)
        {
            int[] result = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "O")
                    {
                        result[0] = row;
                        result[1] = col;
                    }
                }
            }

            return result;
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
