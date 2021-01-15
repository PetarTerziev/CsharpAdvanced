using System;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = ReadMatrix(sizes[0], sizes[1]);
            string commands = Console.ReadLine();
            bool isGameOver = false;
            string message = string.Empty;

            for (int i = 0; i < commands.Length; i++)
            {
                string direction = commands[i].ToString();

                int oldRow = GetStartPosition(matrix)[0];
                int oldCol = GetStartPosition(matrix)[1];

                int[] newCoordinates = MovePlayer(matrix, direction);
                int row = newCoordinates[0];
                int col = newCoordinates[1];

                if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
                {
                    message = $"won: {oldRow} {oldCol}";
                    matrix[oldRow, oldCol] = ".";
                    isGameOver = true;
                }
                else if (IsPlayerHitBunny(matrix, row, col))
                {
                    message = $"dead: {row} {col}";
                    matrix[oldRow, oldCol] = ".";
                    isGameOver = true;
                }
                else
                {
                    matrix[oldRow, oldCol] = ".";
                    matrix[row, col] = "P";
                }

                BunnYSpread(matrix);

                if (!isGameOver && matrix[row, col] == "B")
                {
                    message = $"dead: {row} {col}";
                    isGameOver = true;
                }

                if (isGameOver)
                {
                    break;
                }
            }

            PrintMatrix(matrix);
            Console.WriteLine(message);

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

        static int [] MovePlayer(string[,] matrix, string direction)
        {
            int row = GetStartPosition(matrix)[0];
            int col = GetStartPosition(matrix)[1];

            switch (direction)
            {
                case "U":
                    row -= 1;
                    break;
                case "D":
                    row += 1;
                    break;
                case "L":
                    col -= 1;
                    break;
                case "R":
                    col += 1;
                    break;
            }

            return new int[2] { row, col };
        }

        static string[,] BunnYSpread(string [,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    string currentElement = matrix[row, col];

                    if (currentElement == "B")
                    {
                        if (row - 1 >= 0 && matrix[row - 1, col] != "B")
                        {
                            matrix[row - 1, col] = "b";
                        }

                        if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] != "B")
                        {
                            matrix[row + 1, col] = "b";
                        }

                        if (col - 1 >= 0 && matrix[row, col - 1] != "B")
                        {
                            matrix[row, col - 1] = "b";
                        }

                        if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] != "B")
                        {
                            matrix[row, col + 1] = "b";
                        }
                    }
                }
            }

            return ReplacebWithB(matrix);
        }

        static string[,] ReplacebWithB(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    string currentElement = matrix[row, col];

                    if (currentElement == "b") 
                    {
                        matrix[row, col] = "B";
                    }

                }
            }

            return matrix;
        }

        static bool IsPlayerHitBunny(string[,] matrix, int row, int col) 
        {
            if (matrix[row, col] == "B")
            {
                return true;
            }

            return false;
        }

        static int[] GetStartPosition(string[,] matrix)
        {
            int[] result = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "P")
                    {
                        result[0] = row;
                        result[1] = col;
                    }
                }
            }

            return result;
        }

    }
}
