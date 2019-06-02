using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n = n * 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));
        }
    }
}
