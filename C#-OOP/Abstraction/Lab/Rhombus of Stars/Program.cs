using System;

namespace Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rows; i++)
            {
                PrintRow(i, rows);
            }

            for (int i = rows - 1; i >= 0; i--)
            {
                PrintRow(i, rows);
            }
        }

        private static void PrintRow(int stars, int rows)
        {
            for (int i = 0; i < rows-stars; i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < stars; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}
