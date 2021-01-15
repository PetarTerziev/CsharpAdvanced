using System;
using System.Linq;

namespace Miner
{
    class Miner
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();
            string[,] matrix = ReadMatrix(rows, rows);

            GetMinnigDone(matrix, commands);

        }

        static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        static void GetMinnigDone(string [,] matrix, string[] directions) 
        {
            string message = string.Empty;
            int row = GetStartPosition(matrix)[0];
            int col = GetStartPosition(matrix)[1];

            for (int i = 0; i < directions.Length; i++)
            {
                string nextDirection = directions[i];

                switch (nextDirection)
                {
                    case "up":
                        row = Math.Max(row - 1 , 0); 
                        break;
                    case "down":
                        row = Math.Min(row + 1, matrix.GetLength(0) - 1);
                        break;
                    case "left":
                        col = Math.Max(col - 1, 0);
                        break;
                    case "right":
                        col = Math.Min(col + 1, matrix.GetLength(1) - 1);
                        break;
                }

                string symbol = matrix[row, col];

                if (symbol == "c")
                {
                    matrix[row, col] = "*";
                }
                else if(symbol == "e")
                {
                    message = $"Game over! ({row}, {col})";
                    break;
                }
            }

            if (message == "" && IsAllCoalCollected(matrix))
            {
                message = $"You collected all coals! ({row}, {col})";
            }
            else if (message == "" && !IsAllCoalCollected(matrix))
            {
                message = $"{CountNotCollectedCoal(matrix)} coals left. ({row}, {col})";
            }

            Console.WriteLine(message);
        }

        static int[] GetStartPosition(string[,] matrix) 
        {
            int[] result = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "s")
                    {
                        result[0] = row;
                        result[1] = col;
                    }
                }
            }

            return result;
        }

        static bool IsAllCoalCollected(string[,] matrix) 
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "c")
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static int CountNotCollectedCoal(string[,] matrix) 
        {
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "c")
                    {
                        count ++;
                    }
                }
            }

            return count;
        }
    }
}
