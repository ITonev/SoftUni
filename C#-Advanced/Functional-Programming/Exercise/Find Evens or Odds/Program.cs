using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var start = range[0];
            var end = range[1];

            var command = Console.ReadLine();

            List<int> numbers = new List<int>();

            Predicate<int> evenOrOdds = num => command == "even" ? num % 2 == 0 : num % 2 != 0;

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine(string.Join(" ", numbers.Where(x=>evenOrOdds(x))));
        }
    }
}
