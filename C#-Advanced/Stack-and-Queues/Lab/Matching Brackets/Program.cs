using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var symbol = input[i];

                if (symbol=='(')
                {
                    stack.Push(i);
                }

                else if (symbol==')')
                {
                    int startIndex = stack.Pop();

                    string substring = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
