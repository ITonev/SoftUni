using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Queue<int> numbers = new Queue<int>();

            Func<int, int, bool> Func = (x, y) => x % y != 0;

            for (int i = 1; i <= end; i++)
            {
                bool isValid = true;

                foreach (var num in dividers)
                {
                    if (Func(i, num))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    numbers.Enqueue(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
