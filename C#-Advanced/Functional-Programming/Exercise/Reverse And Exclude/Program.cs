using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Reverse()
                .Select(int.Parse)
                .ToList();

            int num = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> func = Divisible(numbers, num);

            numbers = func(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static Func<List<int>, List<int>> Divisible(List<int> numbers, int num)
        {
            return p => p.Where(x => x % num != 0).ToList();
        }
    }
}
