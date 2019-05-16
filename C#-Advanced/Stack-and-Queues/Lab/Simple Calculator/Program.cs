using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(input.Reverse());

            var result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                var opr = stack.Pop();

                switch (opr)
                {
                    case "+":
                        result += int.Parse(stack.Pop());
                        break;
                    case "-":
                        result -= int.Parse(stack.Pop());
                        break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
