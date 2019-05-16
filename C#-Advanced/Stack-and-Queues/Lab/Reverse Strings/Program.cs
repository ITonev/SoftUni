using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reverseInput = new Stack<char>();

            foreach (var ch in input)
            {
                reverseInput.Push(ch);
            }

            Console.WriteLine(string.Join("", reverseInput));

        }
    }
}
