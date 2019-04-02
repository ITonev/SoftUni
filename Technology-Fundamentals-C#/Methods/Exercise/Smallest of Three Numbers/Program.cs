using System;

namespace Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            PrintSmallestNum(first, second, third);
        }

        private static void PrintSmallestNum(int first, int second, int third)
        {
            Console.WriteLine(Math.Min(Math.Min(first, second), Math.Min(second, third)));
        }
    }
}
