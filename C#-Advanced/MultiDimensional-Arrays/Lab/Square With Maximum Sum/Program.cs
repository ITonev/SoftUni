using System;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentCol = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentCol[col];
                }
            }

            int startingRow = -1;
            int startingCol = -1;
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                int currentValue=int.MinValue;

                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    currentValue = matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1];

                    if (currentValue>maxSum)
                    {
                        maxSum = currentValue;
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[startingRow, startingCol]} {matrix[startingRow, startingCol+1]}\n" +
                $"{matrix[startingRow+1, startingCol]} {matrix[startingRow+1, startingCol+1]}");
            Console.WriteLine(maxSum);
        }
    }
}
