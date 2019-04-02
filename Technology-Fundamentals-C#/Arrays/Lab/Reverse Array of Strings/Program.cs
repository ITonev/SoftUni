using System;
using System.Linq;

namespace Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] arrayOfStrings = Console.ReadLine()
                .Split()
                .Reverse()
                .ToArray();

            Console.WriteLine(string.Join(" ", arrayOfStrings));
        }
    }
}
