using System;
using System.Linq;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            PrintVowelsCount(text);

        }

        private static void PrintVowelsCount(string text)
        {
            int vowelsCount = text.Count(x=>"aeiou".Contains(x.ToString().ToLower()));
            Console.WriteLine(vowelsCount);

        }
    }
}
