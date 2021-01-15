using System;
using System.Collections.Generic;
using System.Linq;

namespace JaggedArrayManipulator
{
    class JaggedArrayManipulator
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = ReadJagged(new double[rows][]);
            jagged = ModifyJaggedByRowsLength(jagged);

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "End")
                {
                    foreach (var item in jagged)
                    {
                        Console.WriteLine(string.Join(" ", item));
                    }

                    break;
                }

                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (row < 0 || row >= jagged.Length || col < 0 || col >= jagged[row].Length)
                {
                    continue;
                }

                double value = double.Parse(tokens[3]);


                switch (command)
                {
                    case "Add":
                        jagged[row][col] += value;
                        break;
                    case "Subtract":
                        jagged[row][col] -= value;
                        break;
                }
            }

        }

        static double[][] ReadJagged(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                double[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                matrix[row] = new double[rowData.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = rowData[col];
                }
            }

            return matrix;
        }

        static double[][] ModifyJaggedByRowsLength(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(x => x * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }
            }

            return matrix;
        }
    }
}
