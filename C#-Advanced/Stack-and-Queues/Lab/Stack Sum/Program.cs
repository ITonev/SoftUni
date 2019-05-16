using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(input);

            var command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                var tokens = command.Split();


                if (tokens[0].ToLower() == "add")
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        numbers.Push(int.Parse(tokens[i]));
                    }
                }

                else if (tokens[0].ToLower()=="remove" && numbers.Count>int.Parse(tokens[1]))
                {
                    for (int i = 1; i <= int.Parse(tokens[1]); i++)
                    {
                        numbers.Pop();
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
