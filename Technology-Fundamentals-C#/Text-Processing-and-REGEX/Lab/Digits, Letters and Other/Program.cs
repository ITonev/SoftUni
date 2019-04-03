using System;

namespace Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            var digits = string.Empty;
            var strings = string.Empty;
            var chars = string.Empty;

            var text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    digits += text[i];
                }
                else if (char.IsLetter(text[i]))
                {
                    strings += (text[i]);
                }
                else
                {
                    chars += (text[i]);
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(strings);
            Console.WriteLine(chars);
        }
    }
}
