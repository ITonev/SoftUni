using System;

namespace Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            int totalSum = 0;

            for (int i = startNumber; i <=endNumber; i++)
            {
                Console.Write(i+" ");
                totalSum += i;
            }

            Console.WriteLine($"\nSum: {totalSum}");
        }
    }
}
