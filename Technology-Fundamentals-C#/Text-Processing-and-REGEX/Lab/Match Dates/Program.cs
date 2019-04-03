using System;
using System.Text.RegularExpressions;

namespace Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();

            var result = Regex.Matches(input, @"(?<days>\d{2})([-\/.])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})");

            foreach (Match match in result)
            {
                Console.WriteLine($"Day: {match.Groups["days"].Value}, Month: {match.Groups["month"].Value}, Year: {match.Groups["year"].Value}");
            }

        }
    }
}
