using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var cols = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = cols[col];
                }
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[i, matrix.GetLength(0) - 1 - i];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
