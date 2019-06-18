using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var frogJumps = new Lake(arr);

            Console.WriteLine(string.Join(", ", frogJumps));
        }
    }
}
