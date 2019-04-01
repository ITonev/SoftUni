using System;
using System.Linq;
using System.Numerics;

namespace From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long[] numbers = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                long highestNum = numbers[1];

                if (numbers[0] > numbers[1])
                {
                    highestNum = numbers[0];
                }

                long sum = 0;
                while (highestNum != 0)
                {
                    sum += (highestNum % 10);
                    highestNum /= 10;
                }
                Console.WriteLine(Math.Abs(sum));
            }
        }
    }
}
