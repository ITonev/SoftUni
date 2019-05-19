using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[size[0], size[1]];

            int equalSquaresCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var cols = Console.ReadLine()
                    .Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = cols[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] 
                        && matrix[row, col] == matrix[row+1, col]
                        && matrix[row, col] == matrix[row+1, col+1])
                    {
                        equalSquaresCount++;
                    }
                }
            }

            Console.WriteLine(equalSquaresCount);
        }
    }
}
