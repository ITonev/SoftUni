using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> funcSmallest = SmallestNum;

            var smallestNum = funcSmallest(numbers);

            Console.WriteLine(smallestNum);
        }

        private static int SmallestNum(List<int> arg)
        {
            int smallest = int.MaxValue;

            foreach (var num in arg)
            {
                if (num < smallest)
                {
                    smallest = num;
                }
            }

            return smallest;
        }
    }
}
