using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(upperCase)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public static Func<string, bool> upperCase = n => n[0] == n.ToUpper()[0];
    }
}
