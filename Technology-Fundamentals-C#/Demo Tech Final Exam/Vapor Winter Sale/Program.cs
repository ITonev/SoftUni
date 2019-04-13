using System;
using System.Collections.Generic;
using System.Linq;

namespace Vapor_Winter_Sale
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();

            Dictionary<string, double> gamePrices = new Dictionary<string, double>();
            Dictionary<string, string> gameDLC = new Dictionary<string, string>();

            for (int i = 0; i < input.Count; i++)
            {
                var pair = input[i].Split(new char[] { '-', ':' }, StringSplitOptions.RemoveEmptyEntries);
                var game = pair[0];

                if (input[i].Contains("-"))
                {
                    double price = double.Parse(pair[1]);
                    gamePrices[game] = price;
                }

                else if (input[i].Contains(":"))
                {
                    var DLC = pair[1];

                    if (gamePrices.ContainsKey(game))
                    {
                        gameDLC[game] = DLC;
                        gamePrices[game] = gamePrices[game] * 1.2;
                        gamePrices[game] = gamePrices[game] * 0.5;
                    }
                }                
            }

            var newGamePrices = new Dictionary<string, double>();

            foreach (var game in gamePrices)
            {
                if (!gameDLC.ContainsKey(game.Key))
                {
                    newGamePrices[game.Key] = game.Value * 0.8;
                }
            }

            foreach (var game in gamePrices.OrderBy(x => x.Value))
            {
                if (gameDLC.ContainsKey(game.Key))
                {
                    Console.WriteLine($"{game.Key} - {gameDLC[game.Key]} - {game.Value:f2}");
                }
            }

            foreach (var game in newGamePrices.OrderByDescending(x=>x.Value))
            {
                if (!gameDLC.ContainsKey(game.Key))
                {
                    Console.WriteLine($"{game.Key} - {game.Value:f2}");
                }
            }
        }
    }
}
