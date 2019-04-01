using System;
using System.Numerics;

namespace Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            decimal totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                totalSum += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(totalSum);
        }
    }
}
