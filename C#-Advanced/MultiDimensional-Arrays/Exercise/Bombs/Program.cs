using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var cols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = cols[col];
                }
            }

            var coodrinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < coodrinates.Length; i++)
            {
                var tokens = coodrinates[i]
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var row = tokens[0];
                var col = tokens[1];
                int damage = matrix[row, col];

                if (damage > 0)
                {
                    BombCells(row - 1, col - 1, damage, matrix);
                    BombCells(row - 1, col, damage, matrix);
                    BombCells(row - 1, col + 1, damage, matrix);
                    BombCells(row, col - 1, damage, matrix);
                    BombCells(row, col + 1, damage, matrix);
                    BombCells(row + 1, col - 1, damage, matrix);
                    BombCells(row + 1, col, damage, matrix);
                    BombCells(row + 1, col + 1, damage, matrix);

                    matrix[row, col] = 0;
                }

            }

            int count = 0;
            int sum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void BombCells(int row, int col, int damage, int[,] matrix)
        {
            if (row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(0)
                && matrix[row, col] > 0)
            {
                matrix[row, col] -= damage;
            }
        }
    }
}
