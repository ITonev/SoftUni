using System;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, List<string>>>(); //continents -> counties-> list of cities

            for (int i = 0; i < num; i++)
            {
                var pair = Console.ReadLine().Split();
                var continent = pair[0];
                var country = pair[1];
                var city = pair[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country] = new List<string>();
                }

                continents[continent][country].Add(city);
            }

            foreach (var kvp in continents)
            {
                var currentContinent = kvp.Key;
                var contries = kvp.Value;

                Console.WriteLine($"{currentContinent}:");

                foreach (var kvpCountry in contries)
                {
                    var currentCountry = kvpCountry.Key;
                    var cities = kvpCountry.Value;

                    Console.WriteLine($"{currentCountry} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
