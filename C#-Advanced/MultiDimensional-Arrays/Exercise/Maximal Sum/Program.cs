using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            var maxSum = int.MinValue;
            var startingRow = -1;
            var startingCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var cols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = cols[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                var currentSum = int.MinValue;

                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                            + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                            + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[startingRow, startingCol]} {matrix[startingRow, startingCol + 1]} {matrix[startingRow, startingCol + 2]}\n" +
                $"{matrix[startingRow + 1, startingCol]} {matrix[startingRow + 1, startingCol + 1]} {matrix[startingRow + 1, startingCol + 2]}\n" +
                $"{matrix[startingRow + 2, startingCol]} {matrix[startingRow + 2, startingCol + 1]} {matrix[startingRow + 2, startingCol + 2]}");
        }
    }
}
