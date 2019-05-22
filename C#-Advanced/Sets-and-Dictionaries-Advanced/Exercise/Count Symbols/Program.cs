using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToCharArray();

            Dictionary<char, int> symbols = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                var currentChar = text[i];

                if (!symbols.ContainsKey(currentChar))
                {
                    symbols[currentChar] = 0;
                }

                symbols[currentChar]++;
            }

            foreach (var kvp in symbols.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
