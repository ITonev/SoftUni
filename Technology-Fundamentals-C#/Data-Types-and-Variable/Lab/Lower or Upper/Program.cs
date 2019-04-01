using System;

namespace Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char currentSymbol = char.Parse(Console.ReadLine());

            if (currentSymbol<97)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
