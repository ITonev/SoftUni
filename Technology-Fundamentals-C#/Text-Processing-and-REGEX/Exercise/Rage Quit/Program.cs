using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            Regex reg = new Regex(@"([^\d]+)(\d+)");

            StringBuilder finalText = new StringBuilder();

            var messages = reg.Matches(text);

            foreach (Match match in messages)
            {
                var message = match.Groups[1].Value;
                var repeat = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < repeat; i++)
                {
                    finalText.Append(message.ToUpper());
                }
            }

            var uniqueSymbols = finalText.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(finalText.ToString());
        }
    }
}
