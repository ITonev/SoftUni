using System;

namespace Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                PrintLine(1, i);
            }

            for (int j = number - 1; j >= 0; j--)
            {
                PrintLine(1, j);
            }
        }

        private static void PrintLine(int firstNum, int secondNum)
        {
            for (int i = firstNum; i <= secondNum; i++)
            {
                Console.Write(i+ " ");
            }
            Console.WriteLine();
        }
    }
}
