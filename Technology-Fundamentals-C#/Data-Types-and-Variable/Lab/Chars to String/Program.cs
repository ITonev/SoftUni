using System;

namespace Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstSymbol = Console.ReadLine();
            string secondSymbol = Console.ReadLine();
            string thirdSymbol = Console.ReadLine();

            string[] symbolChars = new string[3] { firstSymbol,secondSymbol,thirdSymbol};

            Console.WriteLine(string.Join("", symbolChars));
        }
    }
}
