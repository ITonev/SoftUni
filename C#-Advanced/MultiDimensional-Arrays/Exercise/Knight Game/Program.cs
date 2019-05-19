using System;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            for (int row = 0; row < matrix.Length; row++)
            {
                var col = Console.ReadLine().ToCharArray();
                matrix[row] = col;
            }

            int knigtsToRemove = 0;

            while (true)
            {
                int knightRow = -1;
                int knightCol = -1;
                int maxAttacks = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            int currentAttacks = KnightAttacks(matrix, row, col);

                            if (currentAttacks > maxAttacks)
                            {
                                maxAttacks = currentAttacks;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                if (maxAttacks>0)
                {
                    matrix[knightRow][knightCol] = 'O';
                    knigtsToRemove++;
                }

                else
                {
                    break;
                }
            }

            Console.WriteLine(knigtsToRemove);
        }

        private static int KnightAttacks(char[][] matrix, int row, int col)
        {
            int currentAttacks = 0;

            if (IsInMatrix(row - 1, col - 2, matrix) && matrix[row - 1][col - 2] == 'K')
            {
                currentAttacks++;
            }

            if (IsInMatrix(row - 1, col + 2, matrix) && matrix[row - 1][col + 2] == 'K')
            {
                currentAttacks++;
            }

            if (IsInMatrix(row - 2, col - 1, matrix) && matrix[row - 2][col - 1] == 'K')
            {
                currentAttacks++;
            }

            if (IsInMatrix(row - 2, col + 1, matrix) && matrix[row - 2][col + 1] == 'K')
            {
                currentAttacks++;
            }

            if (IsInMatrix(row + 1, col - 2, matrix) && matrix[row + 1][col - 2] == 'K')
            {
                currentAttacks++;
            }

            if (IsInMatrix(row + 1, col + 2, matrix) && matrix[row + 1][col + 2] == 'K')
            {
                currentAttacks++;
            }

            if (IsInMatrix(row + 2, col - 1, matrix) && matrix[row + 2][col - 1] == 'K')
            {
                currentAttacks++;
            }

            if (IsInMatrix(row + 2, col + 1, matrix) && matrix[row + 2][col + 1] == 'K')
            {
                currentAttacks++;
            }

            return currentAttacks;
        }

        private static bool IsInMatrix(int row, int col, char[][] matrix)
        {
            if (row >= 0
                && col >= 0
                && row < matrix.Length
                && col < matrix.Length)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
