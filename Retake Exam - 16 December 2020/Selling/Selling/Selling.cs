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
            bool isPlayerOut = false;
            int money = 0;

            while (money < 50 && !isPlayerOut)
            {
                string direction = Console.ReadLine();
                int oldRow = GetPosition(store, "S")[0];
                int oldCol = GetPosition(store, "S")[1];

                int row = GetPlayerNewPosition(oldRow, oldCol, direction)[0];
                int col = GetPlayerNewPosition(oldRow, oldCol, direction)[1];

                store[oldRow, oldCol] = "-";

                if (row < 0 || row >= store.GetLength(0) || 
                    col < 0 || col >= store.GetLength(1))
                {
                    isPlayerOut = true;
                }
                else
                {
                    string sign = store[row, col];

                    if (sign == "O")
                    {
                        store[row, col] = "-";
                        store[GetPosition(store, "O")[0], GetPosition(store, "O")[1]] = "S";
                        continue;
                    }
                    else if (sign != "-")
                    {
                        money += int.Parse(sign);
                    }

                    store[row, col] = "S";
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
