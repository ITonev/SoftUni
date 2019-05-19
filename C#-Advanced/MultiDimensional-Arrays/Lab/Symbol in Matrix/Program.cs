using System;
using System.Linq;

namespace Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];


            for (int row = 0; row < size; row++)
            {
                char[] currentCol = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentCol[col];
                }
            }

            var symbol = char.Parse(Console.ReadLine());

            bool OccurenceFound = false;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        OccurenceFound = true;

                        Console.WriteLine($"({row}, {col})");

                        break;
                    }
                }

                if (OccurenceFound)
                {
                    break;
                }
            }

            if (!OccurenceFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
