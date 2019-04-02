using System;
using System.Numerics;

namespace Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine($"{((double)Factorial(firstNum) / Factorial(secondNum)):f2}");

        }

        private static long Factorial(int number)
        {
            long factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
