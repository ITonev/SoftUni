using System;
using System.Collections.Generic;
using System.Linq;

namespace Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            number.RemoveAll(x => x < 0);
            number.Reverse();

            if (number.Count==0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", number));
            }
        }
    }
}
