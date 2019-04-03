using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var starCount = 0;

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            Regex fullPattern = new Regex(@"(?<planetName>[A-Za-z]+)[^@\-!:>]*:(?<population>[0-9]+)[^@\-!:>]*!(?<type>[A|D])![^@\-!:>]*->(?<soldiers>[0-9]+)");
            //string fullPattern = @"@([a-zA-Z]+)[^@\-!:>]*:([0-9]+)[^@\-!:>]*!([AD])![^@\-!:>]*->([0-9]+)";

            for (int i = 0; i < num; i++)
            {
                var decryptedMessage = string.Empty;
                var input = Console.ReadLine();
                starCount = Regex.Matches(input, @"[starSTAR]").Count;

                var decrypted = input.Select(x => (char)(x - starCount));

                foreach (var @char in decrypted)
                {
                    decryptedMessage += @char;
                }

                if (fullPattern.IsMatch(decryptedMessage))
                {
                    var result = fullPattern.Match(decryptedMessage);
                    var planetName = result.Groups["planetName"].Value;
                    var AorD = result.Groups["type"].Value;

                    if (AorD.ToString() == "A")
                    {
                        attackedPlanets.Add(planetName.ToString());
                    }

                    else
                    {
                        destroyedPlanets.Add(planetName.ToString());
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count()}");
            foreach (var planet in attackedPlanets.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count()}");
            foreach (var planet in destroyedPlanets.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
