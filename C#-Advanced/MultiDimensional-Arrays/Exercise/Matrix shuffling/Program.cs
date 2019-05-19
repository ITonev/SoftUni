using System;
using System.Linq;

namespace Matrix_shuffling
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

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var cols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = cols[col];
                }
            }

            var input = string.Empty;

            while ((input = Console.ReadLine())!="END")
            {
                var tokens = input.Split();

                if (tokens.Length!=5 || tokens[0]!="swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var firstRow = int.Parse(tokens[1]);
                var firstCol = int.Parse(tokens[2]);
                var secondRow = int.Parse(tokens[3]);
                var secondCol = int.Parse(tokens[4]);

                if (firstRow<0
                    || firstCol<0
                    || secondRow<0
                    || secondCol<0
                    || firstRow>matrix.GetLength(0)-1
                    || firstCol>matrix.GetLength(1)-1
                    || secondRow > matrix.GetLength(0) - 1
                    || secondCol > matrix.GetLength(1) - 1)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var toSwap = matrix[firstRow, firstCol];
                var swap = matrix[secondRow, secondCol];
                matrix[firstRow, firstCol] = swap;
                matrix[secondRow, secondCol] = toSwap;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row,col]} ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
