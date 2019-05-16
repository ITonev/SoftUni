using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var queryType = input[0];

                switch (queryType)
                {
                    case "1":
                        var number = int.Parse(input[1]);
                        stack.Push(number);
                        break;

                    case "2":
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;

                    case "3":
                        Console.WriteLine(stack.Max());
                        break;

                    case "4":
                        Console.WriteLine(stack.Min());
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
