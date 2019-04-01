using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            List<int> sorted = new List<int>() { first, second, third };

            var sortedList = sorted.OrderByDescending(x => x).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, sortedList));
        }
    }
}
