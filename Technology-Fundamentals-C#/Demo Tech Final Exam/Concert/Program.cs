using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var bands = new Dictionary<string, List<string>>();
            var bandsPlaytime = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "start of concert")
                {
                    break;
                }

                var tokens = command.Split("; ");
                string bandName = tokens[1];

                if (tokens[0] == "Add")
                {
                    var members = tokens[2].Split(", ");

                    if (!bands.ContainsKey(bandName))
                    {
                        bands[bandName] = new List<string>();
                        bandsPlaytime[bandName] = 0;
                    }

                    foreach (var member in members)
                    {
                        if (!bands[bandName].Contains(member))
                        {
                            bands[bandName].Add(member);
                        }
                    }
                }

                else if (tokens[0] == "Play")
                {
                    int playTime = int.Parse(tokens[2]);

                    if (!bands.ContainsKey(bandName))
                    {
                        bands[bandName] = new List<string>();
                        bandsPlaytime[bandName] = 0;
                    }

                    bandsPlaytime[bandName] += playTime;
                }
            }

            string bandToPrint = Console.ReadLine();

            Console.WriteLine($"Total time: {bandsPlaytime.Values.Sum()}");

            foreach (var band in bandsPlaytime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            foreach (var band in bands.Where(x=>x.Key==bandToPrint))
            {
                var members = band.Value;
                Console.WriteLine(bandToPrint);
                Console.WriteLine($"=> {string.Join("\n=> ", members)}");
            }
        }
    }
}
