using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class Program
    {
        public static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimestions[0], dimestions[1]];

            FillMatrix(matrix);

            string command = Console.ReadLine();

            long IvoTotalSum = 0;

            while (command != "Let the Force be with you")
            {
                int[] IvoLocation = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilLocation = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evilLocation[0];
                int evilCol = evilLocation[1];

                while (evilRow >= 0 && evilCol >= 0)
                {

                    if (MatrixBoundriesCheck(matrix, evilRow, evilCol))
                    {
                        matrix[evilRow, evilCol] = 0;
                    }

                    evilRow--;
                    evilCol--;
                }

                int ivoRow = IvoLocation[0];
                int ivoCol = IvoLocation[1];

                while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
                {
                    if (MatrixBoundriesCheck(matrix, ivoRow,ivoCol))
                    {
                        IvoTotalSum += matrix[ivoRow, ivoCol];
                    }

                    ivoRow--;
                    ivoCol++;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(IvoTotalSum);
        }

        private static bool MatrixBoundriesCheck(int[,] matrix, int row, int col)
        {
            if (row >= 0 
                && row < matrix.GetLength(0) 
                && col >= 0 
                && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private static void FillMatrix(int[,] matrix)
        {
            int currentCellValue = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentCellValue++;
                }
            }
        }
    }
}
