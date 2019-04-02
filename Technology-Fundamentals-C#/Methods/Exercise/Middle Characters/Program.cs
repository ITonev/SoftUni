using System;

namespace Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            PrintMiddleChar(text);

        }

        private static void PrintMiddleChar(string text)
        {
            if (text.Length % 2 == 0)
            {
                Console.WriteLine($"{text[text.Length / 2 - 1]}{text[text.Length / 2]}");
            }
            else
            {
                Console.WriteLine($"{text[text.Length / 2]}");
            }
        }
    }
}
