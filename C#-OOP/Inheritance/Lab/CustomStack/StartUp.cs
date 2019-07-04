using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            stack.AddRange("Ivan", "Pesh", "Gos", "Some", "Noone");

            Console.WriteLine(stack.IsEmpty());

        }
    }
}
