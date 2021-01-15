using System;

namespace KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[,] matrix = ReadMatrix(rows, rows);

            Console.WriteLine(CountKnightsToRemove(matrix));
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

        static int CountKnightsToRemove(string[,] matrix) 
        {
            int counter = 0;
            int[] posKnightMaxAttack = new int[2];

            while (true)
            {
                int maxAttackByKnight = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        string currentElement = matrix[row, col];
                        int countAttackOfCurrentKnight = 0;

                        if (currentElement == "K")
                        {
                            if (row + 2 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1))
                            {
                                string nextMove = matrix[row + 2, col + 1];

                                if (currentElement == nextMove)
                                {
                                    countAttackOfCurrentKnight++;
                                }
                            }

                            if (row + 2 < matrix.GetLength(0) && col - 1 >= 0)
                            {
                                string nextMove = matrix[row + 2, col - 1];

                                if (currentElement == nextMove)
                                {
                                    countAttackOfCurrentKnight++;
                                }
                            }

                            if (row + 1 < matrix.GetLength(0) && col + 2 < matrix.GetLength(1))
                            {
                                string nextMove = matrix[row + 1, col + 2];

                                if (currentElement == nextMove)
                                {
                                    countAttackOfCurrentKnight++;
                                }
                            }


                            if (row + 1 < matrix.GetLength(0) && col - 2 >= 0)
                            {
                                string nextMove = matrix[row + 1, col - 2];

                                if (currentElement == nextMove)
                                {
                                    countAttackOfCurrentKnight++;
                                }
                            }

                            if (row - 1 >= 0 && col + 2 < matrix.GetLength(1))
                            {
                                string nextMove = matrix[row - 1, col + 2];

                                if (currentElement == nextMove)
                                {
                                    countAttackOfCurrentKnight++;
                                }
                            }

                            if (row - 1 >= 0 && col - 2 >= 0)
                            {
                                string nextMove = matrix[row - 1, col - 2];

                                if (currentElement == nextMove)
                                {
                                    countAttackOfCurrentKnight++;
                                }
                            }

                            if (row - 2 >= 0 && col + 1 < matrix.GetLength(1))
                            {
                                string nextMove = matrix[row - 2, col + 1];

                                if (currentElement == nextMove)
                                {
                                    countAttackOfCurrentKnight++;
                                }
                            }

                            if (row - 2 >= 0 && col - 1 >= 0)
                            {
                                string nextMove = matrix[row - 2, col - 1];

                                if (currentElement == nextMove)
                                {
                                    countAttackOfCurrentKnight++;
                                }
                            }

                            if (countAttackOfCurrentKnight > maxAttackByKnight)
                            {
                                maxAttackByKnight = countAttackOfCurrentKnight;
                                posKnightMaxAttack[0] = row;
                                posKnightMaxAttack[1] = col;
                            }

                        }
                    }
                }

                if (maxAttackByKnight > 0)
                {
                    matrix[posKnightMaxAttack[0], posKnightMaxAttack[1]] = "0";
                    counter++;
                }
                else
                {
                    break;
                }
            }

            return counter;
        }
    }
}
