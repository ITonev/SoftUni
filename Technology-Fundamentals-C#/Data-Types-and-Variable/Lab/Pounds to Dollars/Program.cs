using System;

namespace Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double GBP = double.Parse(Console.ReadLine());

            double gbpToUsd = GBP * 1.31;

            Console.WriteLine($"{gbpToUsd:F3}");
        }
    }
}
