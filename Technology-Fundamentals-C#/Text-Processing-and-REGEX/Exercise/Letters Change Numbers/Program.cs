using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            double totalSum = 0.0;

            for (int i = 0; i < input.Length; i++)
            {
                var currentString = input[i];

                Regex reg = new Regex(@"([\D])([\d]+)([\D])");
                Match match = reg.Match(currentString);
                var firstLetter = match.Groups[1].Value;
                var number = double.Parse(match.Groups[2].Value);
                var secondLetter = match.Groups[3].Value;

                var asciiOfFirstLetter = Convert.ToChar(firstLetter);
                var asciiOfSecondLetter = Convert.ToChar(secondLetter);

                if (asciiOfFirstLetter <= 90)
                {
                    int alphabetPosition = asciiOfFirstLetter - 64;
                    number /= alphabetPosition;
                }

                else if (asciiOfFirstLetter >= 97)
                {
                    int alphabetPosition = asciiOfFirstLetter - 96;
                    number *= alphabetPosition;
                }

                if (asciiOfSecondLetter <= 90)
                {
                    int alphabetPosition = asciiOfSecondLetter - 64;
                    number -= alphabetPosition;
                }

                else if (asciiOfSecondLetter >= 97)
                {
                    int alphabetPosition = asciiOfSecondLetter - 96;
                    number += alphabetPosition;
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
