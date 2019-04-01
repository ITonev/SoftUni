using System;

namespace Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int startingMultiplier = int.Parse(Console.ReadLine());

            Console.WriteLine($"{number} X {startingMultiplier} = {number * startingMultiplier}");

            for (int i = startingMultiplier + 1; i <= 10; i++)
            {
                Console.WriteLine($"{number} X {i} = {number * i}");
            }
        }
    }
}
